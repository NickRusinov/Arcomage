using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class MenuButtonView : View<ButtonViewModel>
    {
        private readonly TextView menuButtonTextView;

        public MenuButtonView(ContentManager contentManager, ButtonViewModel viewModel)
            : base(viewModel, 400, 200)
        {
            var menuButtonBackgroundImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 400, SizeY = 200, SourceX = 400, SourceY = 200,
                Texture = contentManager.Load<Texture2D>("MenuButtonBackgroundImage")
            };

            menuButtonTextView = new TextView
            {
                PositionX = 50, PositionY = 50, SizeX = 300, SizeY = 100,
                Color = Color.Black, Text = ViewModel.Identifier,
                Font = contentManager.Load<SpriteFont>("MenuButtonFont")
            };

            var buttonClickHandlerVisitor = new ButtonClickHandlerVisitor(this);
            var pressScaleHandlerVisitor = new PressScaleHandlerVisitor(this, new Vector2(350, 175));

            Items.Add(menuButtonBackgroundImageView);
            Items.Add(menuButtonTextView);
            HandlerVisitors.Add(buttonClickHandlerVisitor);
            HandlerVisitors.Add(pressScaleHandlerVisitor);
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            menuButtonTextView.Text = ViewModel.Identifier;
        }
    }
}