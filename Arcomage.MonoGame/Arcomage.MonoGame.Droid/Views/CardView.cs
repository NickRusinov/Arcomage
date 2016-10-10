using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Animations;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class CardView : View<CardViewModel>
    {
        private readonly ContentManager contentManager;

        private readonly SpriteView cardBackgroundImageView;

        private readonly SpriteView cardImageView;

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

            Items.Add(cardBackgroundImageView);
            Items.Add(cardImageView);

            var moveAnimation = new MoveAnimation(this);

            Animations.Add(moveAnimation);

            var dragHandlerVisitor = new DragAnimationHandlerVisitor(this, moveAnimation);

            HandlerVisitors.Add(dragHandlerVisitor);
        }

        protected override void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            cardBackgroundImageView.Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Resource }BackgroundImage");

            cardImageView.Texture = contentManager.Load<Texture2D>($"Card{ ViewModel.Identifier }Image");
        }
    }
}
