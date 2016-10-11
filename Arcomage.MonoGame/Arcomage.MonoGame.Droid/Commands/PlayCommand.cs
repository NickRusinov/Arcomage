using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class PlayCommand : Command
    {
        private readonly ContentManager contentManager;

        private readonly PageView pageView;

        public PlayCommand(ContentManager contentManager, PageView pageView)
        {
            this.contentManager = contentManager;
            this.pageView = pageView;
        }

        public override void Execute(object parameter)
        {
            var gameViewModel = new GameViewModel
            {
                ResourcesLeft = new ResourcesViewModel(),
                ResourcesRight = new ResourcesViewModel(),
                BuildingsLeft = new BuildingsViewModel(),
                BuildingsRight = new BuildingsViewModel(),
                CardSet = new CardSetViewModel
                {
                    CardCollection = new ObservableCollection<CardViewModel>()
                }
            };

            var gameView = new GameView(contentManager, gameViewModel)
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720
            };

            pageView.View = gameView;
        }
    }
}