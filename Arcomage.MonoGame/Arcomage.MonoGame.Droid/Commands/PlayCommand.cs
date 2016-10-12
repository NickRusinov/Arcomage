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

        private readonly PageView pageView;

        public PlayCommand(ContentManager contentManager, PageView pageView)
        {
            this.contentManager = contentManager;
            this.pageView = pageView;
        }

        public override void Execute(object parameter)
        {
            pageView.View = new GameView(contentManager, ViewModelFactory.Instance.CreateGameViewModel())
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720
            };
        }
    }
}