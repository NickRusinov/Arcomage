using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class GameView : View<GameViewModel>
    {
        public GameView(ContentManager contentManager)
        {
            var gameBorderImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720,
                Texture = contentManager.Load<Texture2D>("GameBorderImage")
            };

            var gameBackgroundImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720,
                Texture = contentManager.Load<Texture2D>("GameBackgroundImage")
            };

            var panelView = new PanelView();
            panelView.Items.Add(gameBackgroundImageView);
            panelView.Items.Add(gameBorderImageView);

            Content = panelView;
        }
    }
}
