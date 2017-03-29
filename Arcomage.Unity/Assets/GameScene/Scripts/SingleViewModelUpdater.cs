using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Services;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.ViewModels;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class SingleViewModelUpdater
    {
        private readonly GameViewModel viewModel;

        private readonly DiContainer container;

        public SingleViewModelUpdater(GameViewModel viewModel, DiContainer container)
        {
            this.viewModel = viewModel;
            this.container = container;
        }

        public GameViewModel Update(Game game)
        {
            return Update(viewModel, game, container.Resolve<ClassicRuleInfo>());
        }

        private GameViewModel Update(GameViewModel viewModel, Game game, ClassicRuleInfo ruleInfo)
        {
            viewModel = viewModel ?? new GameViewModel();
            viewModel.LeftBuildings = Update(viewModel.LeftBuildings, game.Players.FirstPlayer.Buildings, ruleInfo);
            viewModel.LeftResources = Update(viewModel.LeftResources, game.Players.FirstPlayer.Resources, PlayerKind.First);
            viewModel.RightBuildings = Update(viewModel.RightBuildings, game.Players.SecondPlayer.Buildings, ruleInfo);
            viewModel.RightResources = Update(viewModel.RightResources, game.Players.SecondPlayer.Resources, PlayerKind.Second);
            viewModel.FinishedMenu = Update(viewModel.FinishedMenu, game);
            viewModel.Hand = Update(viewModel.Hand, game, game.Players.FirstPlayer, game.Players.FirstPlayer.Hand);
            viewModel.History = Update(viewModel.History, game.History);
            viewModel.PlayerKind = game.Players.Kind;
            viewModel.DiscardOnly = game.DiscardOnly;

            return viewModel;
        }

        private BuildingsViewModel Update(BuildingsViewModel viewModel, BuildingSet buildingSet, ClassicRuleInfo ruleInfo)
        {
            viewModel = viewModel ?? new BuildingsViewModel();
            viewModel.Wall = buildingSet.Wall;
            viewModel.Tower = buildingSet.Tower;
            viewModel.MaxWall = ruleInfo.MaxTower;
            viewModel.MaxTower = ruleInfo.MaxTower;

            return viewModel;
        }

        private ResourcesViewModel Update(ResourcesViewModel viewModel, ResourceSet resourceSet, PlayerKind playerKind)
        {
            viewModel = viewModel ?? new ResourcesViewModel();
            viewModel.Name = playerKind.GetName();
            viewModel.Quarry = resourceSet.Quarry;
            viewModel.Bricks = resourceSet.Bricks;
            viewModel.Magic = resourceSet.Magic;
            viewModel.Gems = resourceSet.Gems;
            viewModel.Dungeons = resourceSet.Dungeons;
            viewModel.Recruits = resourceSet.Recruits;

            return viewModel;
        }

        private HandViewModel Update(HandViewModel viewModel, Game game, Player player, Hand hand)
        {
            viewModel = viewModel ?? new HandViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<CardViewModel>();
            viewModel.Cards = hand.Cards
                .Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), game, player, c, i))
                .ToArray();

            return viewModel;
        }

        private HistoryViewModel Update(HistoryViewModel viewModel, History history)
        {
            viewModel = viewModel ?? new HistoryViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<HistoryCardViewModel>();
            viewModel.Cards = history.Cards
                .Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c, i))
                .ToArray();

            return viewModel;
        }

        private CardViewModel Update(CardViewModel viewModel, Game game, Player player, Card card, int index)
        {
            var playCardCriteria = container.Resolve<IPlayCardCriteria>();
            var discardCardCriteria = container.Resolve<IDiscardCardCriteria>();

            if (viewModel != null && viewModel.Id != card.Index)
                viewModel = new CardViewModel();

            viewModel = viewModel ?? new CardViewModel();
            viewModel.Id = card.Index;
            viewModel.Index = index;
            viewModel.PlayCommand = viewModel.PlayCommand ?? container.Resolve<SinglePlayCardCommand>();
            viewModel.DiscardCommand = viewModel.DiscardCommand ?? container.Resolve<SingleDiscardCardCommand>();
            viewModel.Identifier = card.GetIdentifier();
            viewModel.Kind = card.Kind;
            viewModel.Price = card.Price;
            viewModel.IsPlay = playCardCriteria.CanPlayCard(game, player, index);
            viewModel.IsDiscard = discardCardCriteria.CanDiscardCard(game, player, index);

            return viewModel;
        }

        private HistoryCardViewModel Update(HistoryCardViewModel viewModel, HistoryCard historyCard, int index)
        {
            if (viewModel != null && viewModel.Id != historyCard.Card.Index)
                viewModel = new HistoryCardViewModel();

            viewModel = viewModel ?? new HistoryCardViewModel();
            viewModel.Id = historyCard.Card.Index;
            viewModel.Index = index;
            viewModel.Identifier = historyCard.Card.GetIdentifier();
            viewModel.Kind = historyCard.Card.Kind;
            viewModel.Price = historyCard.Card.Price;
            viewModel.IsPlayed = historyCard.IsPlayed;

            return viewModel;
        }

        private FinishedMenuViewModel Update(FinishedMenuViewModel viewModel, Game game)
        {
            viewModel = viewModel ?? new FinishedMenuViewModel();
            viewModel.Identifier = game.Rule.IsWin(game).GetIdentifier();
            viewModel.Name = game.Rule.IsWin(game).Player.GetName();

            return viewModel;
        }
    }
}
