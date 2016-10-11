using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class MenuView : View<MenuViewModel>
    {
        public MenuView(ContentManager contentManager, MenuViewModel viewModel)
            : base(viewModel, 1280, 720)
        {
            var menuBackgroundImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720, SourceX = 1280, SourceY = 720,
                Texture = contentManager.Load<Texture2D>("MenuBackgroundImage")
            };

            var menuPlayButtonView = new MenuButtonView(contentManager, viewModel.PlayButton)
            {
                PositionX = 440, PositionY = 30, SizeX = 400, SizeY = 200
            };

            var menuSettingsButtonView = new MenuButtonView(contentManager, viewModel.SettingsButton)
            {
                PositionX = 440, PositionY = 260, SizeX = 400, SizeY = 200
            };

            var menuExitButtonView = new MenuButtonView(contentManager, viewModel.ExitButton)
            {
                PositionX = 440, PositionY = 490, SizeX = 400, SizeY = 200
            };

            Items.Add(menuBackgroundImageView);
            Items.Add(menuPlayButtonView);
            Items.Add(menuSettingsButtonView);
            Items.Add(menuExitButtonView);
        }
    }
}