using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Animations;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class CardView : View<CardViewModel>
    {
        private readonly ContentManager contentManager;

        private readonly SpriteView cardBackgroundImageView;

        private readonly SpriteView cardImageView;

        private readonly TextView cardNameTextView;

        private readonly TextView cardDescriptionTextView;

        private readonly TextView cardPriceTextView;

        public CardView(ContentManager contentManager, CardViewModel cardViewModel)
            : base(cardViewModel, 200, 279)
        {
            this.contentManager = contentManager;

            cardBackgroundImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 200, SizeY = 279, SourceX = 200, SourceY = 279,
                Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Resource }BackgroundImage")
            };

            cardImageView = new SpriteView
            {
                PositionX = 20, PositionY = 56, SizeX = 160, SizeY = 108, SourceX = 160, SourceY = 108,
                Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Identifier }Image")
            };

            cardNameTextView = new TextView
            {
                PositionX = 20, PositionY = 16, SizeX = 160, SizeY = 24, 
                Color = Color.Black, Text = contentManager.Load<string>($"Card{ ViewModel.Identifier }Name"),
                Font = contentManager.Load<SpriteFont>("CardFont")
            };

            cardDescriptionTextView = new TextView
            {
                PositionX = 20, PositionY = 174, SizeX = 160, SizeY = 75,
                VerticalAlign = VerticalAlign.Top, HorizontalAlign = HorizontalAlign.Center,
                Color = Color.Black, Text = contentManager.Load<string>($"Card{ ViewModel.Identifier }Description"),
                Font = contentManager.Load<SpriteFont>("CardFont")
            };

            cardPriceTextView = new TextView
            {
                PositionX = 162, PositionY = 240, SizeX = 20, SizeY = 20,
                Color = Color.Black, Text = $"{ ViewModel.Price }",
                Font = contentManager.Load<SpriteFont>("CardFont")
            };

            Items.Add(cardBackgroundImageView);
            Items.Add(cardImageView);
            Items.Add(cardNameTextView);
            Items.Add(cardDescriptionTextView);
            Items.Add(cardPriceTextView);

            var moveAnimation = new MoveAnimation(this);

            Animations.Add(moveAnimation);

            var dragHandlerVisitor = new DragHandlerVisitor(this);
            var dragAnimationHandlerVisitor = new DragAnimationHandlerVisitor(this, moveAnimation);
            var playCardHandlerVisitor = new PlayCardHandlerVisitor(this, - 30);
            var discardCardHandlerVisitor = new DiscardCardHandlerVisitor(this, + 30);

            HandlerVisitors.Add(dragHandlerVisitor);
            HandlerVisitors.Add(dragAnimationHandlerVisitor);
            HandlerVisitors.Add(playCardHandlerVisitor);
            HandlerVisitors.Add(discardCardHandlerVisitor);

            Opacity = ViewModel.CanPlay ? 1f : .75f;
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            cardBackgroundImageView.Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Resource }BackgroundImage");
            
            cardImageView.Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Identifier }Image");
            cardNameTextView.Text = contentManager.Load<string>($"Card{ ViewModel.Identifier }Name");
            cardDescriptionTextView.Text = contentManager.Load<string>($"Card{ ViewModel.Identifier }Description");

            cardPriceTextView.Text = $"{ ViewModel.Price }";

            Opacity = ViewModel.CanPlay ? 1f : .75f;
        }
    }
}
