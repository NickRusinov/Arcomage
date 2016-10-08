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

            var resourcesLeftView = new ResourcesLeftView(contentManager)
            {
                PositionX = 2, PositionY = 9, SizeX = 170, SizeY = 377
            };

            var resourcesRightView = new ResourcesRightView(contentManager)
            {
                PositionX = 1109, PositionY = 9, SizeX = 170, SizeY = 377
            };
            
            Items.Add(gameBackgroundImageView);
            Items.Add(resourcesLeftView);
            Items.Add(resourcesRightView);
            Items.Add(gameBorderImageView);
        }
    }
}
