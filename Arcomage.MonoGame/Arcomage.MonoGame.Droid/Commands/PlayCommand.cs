using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class PlayCommand : Command
    {
        private readonly ContentManager contentManager;

        private readonly MainView mainView;

        public PlayCommand(ContentManager contentManager, MainView mainView)
        {
            this.contentManager = contentManager;
            this.mainView = mainView;
        }

        public override void Execute(object parameter)
        {
            var viewModel = ViewModelFactory.Instance.CreateGameViewModel();
            var view = new GameView(contentManager, viewModel)
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720
            };

            mainView.PageViewModel = viewModel;
            mainView.View = view;
        }
    }
}