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
using Arcomage.Domain.Timers;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class SingleViewModelUpdater
    {
        private readonly SingleSettings settings;

        private readonly GameViewModel viewModel;

        public SingleViewModelUpdater(SingleSettings settings, GameViewModel viewModel)
        {
            this.settings = settings;
            this.viewModel = viewModel;
        }

        public GameViewModel Update(Game game)
        {
            return Update(viewModel, game, (ClassicRuleInfo)settings.Rule);
        }

        private GameViewModel Update(GameViewModel viewModel, Game game, ClassicRuleInfo ruleInfo)
        {
            var leftPlayerKind = settings.PlayerKind;
            var rightPlayerKind = PlayerSet.NextPlayerKind(settings.PlayerKind);
            var leftPlayer = game.Players[leftPlayerKind];
            var rightPlayer = game.Players[rightPlayerKind];

            viewModel = viewModel ?? new GameViewModel();
            viewModel.LeftBuildings = Update(viewModel.LeftBuildings, leftPlayer.Buildings, ruleInfo);
            viewModel.LeftResources = Update(viewModel.LeftResources, leftPlayer.Resources, leftPlayerKind);
            viewModel.RightBuildings = Update(viewModel.RightBuildings, rightPlayer.Buildings, ruleInfo);
            viewModel.RightResources = Update(viewModel.RightResources, rightPlayer.Resources, rightPlayerKind);
            viewModel.FinishedMenu = Update(viewModel.FinishedMenu, game);
            viewModel.Hand = Update(viewModel.Hand, game, leftPlayer, leftPlayer.Hand);
            viewModel.History = Update(viewModel.History, game.History);
            viewModel.Timer = Update(viewModel.Timer, game.Timer);
            viewModel.CurrentPlayerKind = game.Players.Kind;
            viewModel.UserPlayerKind = settings.PlayerKind;
            viewModel.DiscardOnly = game.DiscardOnly;
            viewModel.PlayAgain = game.PlayAgain;

            return viewModel;
        }

        private BuildingsViewModel Update(BuildingsViewModel viewModel, BuildingSet buildingSet, 
            ClassicRuleInfo ruleInfo)
        {
            viewModel = viewModel ?? new BuildingsViewModel();
            viewModel.Wall = buildingSet.Wall;
            viewModel.Tower = buildingSet.Tower;
            viewModel.MaxWall = ruleInfo.MaxTower;
            viewModel.MaxTower = ruleInfo.MaxTower;

            return viewModel;
        }

        private ResourcesViewModel Update(ResourcesViewModel viewModel, ResourceSet resourceSet, 
            PlayerKind playerKind)
        {
            viewModel = viewModel ?? new ResourcesViewModel();
            viewModel.Name = settings.GetName(playerKind);
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
                .ToList();

            return viewModel;
        }

        private HistoryViewModel Update(HistoryViewModel viewModel, History history)
        {
            viewModel = viewModel ?? new HistoryViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<HistoryCardViewModel>();
            viewModel.Cards = history.Cards
                .Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c, i))
                .ToList();

            return viewModel;
        }

        private CardViewModel Update(CardViewModel viewModel, Game game, Player player, Card card, int index)
        {
            if (viewModel != null && viewModel.Id != card.Index)
                viewModel = new CardViewModel();

            viewModel = viewModel ?? new CardViewModel();
            viewModel.Id = card.Index;
            viewModel.Index = index;
            viewModel.Identifier = card.GetIdentifier();
            viewModel.Kind = card.Kind;
            viewModel.Price = card.Price;
            viewModel.IsPlay = game.PlayAction.CanPlay(game, player, new PlayResult(index, true, false, false));
            viewModel.IsDiscard = game.PlayAction.CanPlay(game, player, new PlayResult(index, false, true, false));

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

        private TimerViewModel Update(TimerViewModel viewModel, Timer timer)
        {
            viewModel = viewModel ?? new TimerViewModel();
            viewModel.TimeRest = (float)timer.TimeRest.TotalSeconds;

            return viewModel;
        }

        private FinishedMenuViewModel Update(FinishedMenuViewModel viewModel, Game game)
        {
            viewModel = viewModel ?? new FinishedMenuViewModel();
            viewModel.Identifier = game.Rule.IsWin(game).GetIdentifier();
            viewModel.Name = settings.GetName(game.Rule.IsWin(game).Player);
            viewModel.IsSingle = true;
            viewModel.IsNetwork = false;

            return viewModel;
        }
    }
}
