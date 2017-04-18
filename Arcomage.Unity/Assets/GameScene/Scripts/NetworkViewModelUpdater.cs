using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.WebApi.Client.Models.Game;
using Autofac;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class NetworkViewModelUpdater
    {
        private readonly ILifetimeScope lifetimeScope;

        private readonly GameViewModel viewModel;

        public NetworkViewModelUpdater(ILifetimeScope lifetimeScope, GameViewModel viewModel)
        {
            this.lifetimeScope = lifetimeScope;
            this.viewModel = viewModel;
        }

        public GameViewModel Update(GameModel model)
        {
            return Update(viewModel, model);
        }

        private GameViewModel Update(GameViewModel viewModel, GameModel model)
        {
            viewModel = viewModel ?? new GameViewModel();
            viewModel.LeftBuildings = Update(viewModel.LeftBuildings, model.FirstPlayer.Buildings);
            viewModel.LeftResources = Update(viewModel.LeftResources, model.FirstPlayer.Resources, model.FirstPlayer);
            viewModel.RightBuildings = Update(viewModel.RightBuildings, model.SecondPlayer.Buildings);
            viewModel.RightResources = Update(viewModel.RightResources, model.SecondPlayer.Resources, model.SecondPlayer);
            viewModel.FinishedMenu = Update(viewModel.FinishedMenu, model.Result ?? new GameModel.ResultModel());
            viewModel.Hand = Update(viewModel.Hand, model.Hand);
            viewModel.History = Update(viewModel.History, model.History);
            viewModel.PlayerKind = PlayerKind.First; // TODO
            viewModel.DiscardOnly = model.DiscardOnly;
            viewModel.PlayAgain = model.PlayAgain;

            return viewModel;
        }

        private BuildingsViewModel Update(BuildingsViewModel viewModel, GameModel.BuildingsModel model)
        {
            viewModel = viewModel ?? new BuildingsViewModel();
            viewModel.Wall = model.Wall;
            viewModel.Tower = model.Tower;
            viewModel.MaxWall = model.MaxWall;
            viewModel.MaxTower = model.MaxTower;

            return viewModel;
        }

        private ResourcesViewModel Update(ResourcesViewModel viewModel, GameModel.ResourcesModel model, GameModel.PlayerModel playerModel)
        {
            viewModel = viewModel ?? new ResourcesViewModel();
            viewModel.Name = playerModel.Name;
            viewModel.Quarry = model.Quarry;
            viewModel.Bricks = model.Bricks;
            viewModel.Magic = model.Magic;
            viewModel.Gems = model.Gems;
            viewModel.Dungeons = model.Dungeons;
            viewModel.Recruits = model.Recruits;

            return viewModel;
        }

        private HandViewModel Update(HandViewModel viewModel, GameModel.HandModel model)
        {
            viewModel = viewModel ?? new HandViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<CardViewModel>();
            viewModel.Cards = model.Cards
                .Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c, i))
                .ToList();

            return viewModel;
        }

        private HistoryViewModel Update(HistoryViewModel viewModel, GameModel.HistoryModel model)
        {
            viewModel = viewModel ?? new HistoryViewModel();
            viewModel.Cards = viewModel.Cards ?? new List<HistoryCardViewModel>();
            viewModel.Cards = model.Cards
                .Select((c, i) => Update(viewModel.Cards.ElementAtOrDefault(i), c, i))
                .ToList();

            return viewModel;
        }

        private CardViewModel Update(CardViewModel viewModel, GameModel.CardModel model, int index)
        {
            if (viewModel != null && viewModel.Id != model.Index)
                viewModel = new CardViewModel();

            viewModel = viewModel ?? new CardViewModel();
            viewModel.Id = model.Index;
            viewModel.Index = index;
            viewModel.PlayCommand = viewModel.PlayCommand ?? lifetimeScope.Resolve<NetworkPlayCardCommand>();
            viewModel.DiscardCommand = viewModel.DiscardCommand ?? lifetimeScope.Resolve<NetworkDiscardCardCommand>();
            viewModel.Identifier = model.Identifier;
            viewModel.Kind = (ResourceKind)model.ResourceKind;
            viewModel.Price = model.ResourcePrice;
            viewModel.IsPlay = model.CanPlay;
            viewModel.IsDiscard = model.CanDiscard;

            return viewModel;
        }

        private HistoryCardViewModel Update(HistoryCardViewModel viewModel, GameModel.HistoryCardModel model, int index)
        {
            if (viewModel != null && viewModel.Id != model.Index)
                viewModel = new HistoryCardViewModel();

            viewModel = viewModel ?? new HistoryCardViewModel();
            viewModel.Id = model.Index;
            viewModel.Index = index;
            viewModel.Identifier = model.Identifier;
            viewModel.Kind = (ResourceKind)model.ResourceKind;
            viewModel.Price = model.ResourcePrice;
            viewModel.IsPlayed = model.IsPlayed;

            return viewModel;
        }

        private FinishedMenuViewModel Update(FinishedMenuViewModel viewModel, GameModel.ResultModel model)
        {
            viewModel = viewModel ?? new FinishedMenuViewModel();
            viewModel.Identifier = model.Identifier;
            viewModel.Name = model.WinPlayer;

            return viewModel;
        }
    }
}
