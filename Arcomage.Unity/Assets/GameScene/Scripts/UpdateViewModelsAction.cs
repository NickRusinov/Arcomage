using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Domain.Rules;
using Arcomage.Unity.GameScene.ViewModels;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class UpdateViewModelsAction : IAfterPlayAction, IBeforePlayAction
    {
        private readonly GameViewModel viewModel = new GameViewModel();

        private readonly ClassicRuleInfo ruleInfo;

        public UpdateViewModelsAction(ClassicRuleInfo ruleInfo)
        {
            this.ruleInfo = ruleInfo;
        }

        public void Play(Game game, PlayResult playResult)
        {
            if (Equals(viewModel.game, game))
                Update(game);
        }

        public void Play(Game game)
        {
            if (Equals(viewModel.game, game))
                Update(game);
        }

        public GameViewModel Update(Game game)
        {
            viewModel.game = game;
            viewModel.LeftBuildings = Update(viewModel.LeftBuildings, game.Players.FirstPlayer.Buildings, ruleInfo);
            viewModel.LeftResources = Update(viewModel.LeftResources, game.Players.FirstPlayer.Resources, PlayerKind.First);
            viewModel.RightBuildings = Update(viewModel.RightBuildings, game.Players.SecondPlayer.Buildings, ruleInfo);
            viewModel.RightResources = Update(viewModel.RightResources, game.Players.SecondPlayer.Resources, PlayerKind.Second);
            viewModel.FinishedMenu = Update(viewModel.FinishedMenu, game);
            viewModel.Hand = Update(viewModel.Hand, game.Players.FirstPlayer.Hand);
            viewModel.History = Update(viewModel.History, game.History);
            viewModel.PlayerKind = game.Players.Kind;
            viewModel.DiscardOnly = game.DiscardOnly;

            return viewModel;
        }

        private static BuildingsViewModel Update(BuildingsViewModel viewModel, BuildingSet buildingSet, ClassicRuleInfo ruleInfo)
        {
            viewModel = viewModel ?? new BuildingsViewModel();
            viewModel.Wall = buildingSet.Wall;
            viewModel.Tower = buildingSet.Tower;
            viewModel.MaxWall = ruleInfo.MaxTower;
            viewModel.MaxTower = ruleInfo.MaxTower;

            return viewModel;
        }

        private static ResourcesViewModel Update(ResourcesViewModel viewModel, ResourceSet resourceSet, PlayerKind playerKind)
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

        private static HandViewModel Update(HandViewModel viewModel, Hand hand)
        {
            viewModel = viewModel ?? new HandViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<CardViewModel>();
            viewModel.Cards = hand.Cards.Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c)).ToArray();

            return viewModel;
        }

        private static HistoryViewModel Update(HistoryViewModel viewModel, History history)
        {
            viewModel = viewModel ?? new HistoryViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<HistoryCardViewModel>();
            viewModel.Cards = history.Cards.Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c)).ToArray();

            return viewModel;
        }

        private static CardViewModel Update(CardViewModel viewModel, Card card)
        {
            if (viewModel != null && viewModel.Index != card.Index)
                viewModel = new CardViewModel();

            viewModel = viewModel ?? new CardViewModel();
            viewModel.Index = card.Index;
            viewModel.Identifier = card.GetIdentifier();
            viewModel.Kind = card.Kind;
            viewModel.Price = card.Price;

            return viewModel;
        }

        private static HistoryCardViewModel Update(HistoryCardViewModel viewModel, HistoryCard historyCard)
        {
            if (viewModel != null && viewModel.Index != historyCard.Card.Index)
                viewModel = new HistoryCardViewModel();

            viewModel = viewModel ?? new HistoryCardViewModel();
            viewModel.Index = historyCard.Card.Index;
            viewModel.Identifier = historyCard.Card.GetIdentifier();
            viewModel.Kind = historyCard.Card.Kind;
            viewModel.Price = historyCard.Card.Price;
            viewModel.IsPlayed = historyCard.IsPlayed;

            return viewModel;
        }

        private static FinishedMenuViewModel Update(FinishedMenuViewModel viewModel, Game game)
        {
            viewModel = viewModel ?? new FinishedMenuViewModel();
            viewModel.Identifier = game.Rule.IsWin(game).GetIdentifier();
            viewModel.Name = game.Rule.IsWin(game).Player.GetName();

            return viewModel;
        }
    }
}
