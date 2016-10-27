using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Animations;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid.Views
{
    public class HandView : View<HandViewModel>
    {
        private readonly ContentManager contentManager;

        public HandView(ContentManager contentManager, HandViewModel handViewModel)
            : base(handViewModel, 1270, 315)
        {
            this.contentManager = contentManager;
            handViewModel.CardCollection.CollectionChanged += CardCollectionOnCollectionChanged;

            if (handViewModel.CardCollection.Count != 0)
            {
                var cardOffset = CalculateCardOffset(handViewModel.CardCollection.Count);
                var cardPlace = CalculateCardPlace(handViewModel.CardCollection.Count);
                var cardSize = CalculateCardSize(handViewModel.CardCollection.Count);

                Items.AddRange(handViewModel.CardCollection.Select((vm, i) => InitializeCard(vm, cardOffset, cardPlace, cardSize, i)));
            }
        }

        private void CardCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Replace)
            {
                var cardOffset = CalculateCardOffset(ViewModel.CardCollection.Count);
                var cardPlace = CalculateCardPlace(ViewModel.CardCollection.Count);
                var cardSize = CalculateCardSize(ViewModel.CardCollection.Count);

                var cardViewModel = ViewModel.CardCollection[args.OldStartingIndex];
                var cardView = InitializeCard(cardViewModel, cardOffset, cardPlace, cardSize, args.OldStartingIndex);

                var initialMoveAnimation = new MoveAnimation(cardView);
                initialMoveAnimation.Position = cardView.Position;
                initialMoveAnimation.Interval = TimeSpan.FromMilliseconds(500);

                cardView.Position = new Vector2(385, - 364);
                cardView.Animations.Add(initialMoveAnimation);
                initialMoveAnimation.Reset();

                Items[args.OldStartingIndex] = cardView;
            }
        }

        private CardView InitializeCard(CardViewModel cardViewModel, Vector2 cardOffset, Vector2 cardDelta, Vector2 cardSize, int index)
        {
            return new CardView(contentManager, cardViewModel)
            {
                Position = cardOffset + new Vector2(cardDelta.X, 0) * index,
                Size = cardSize
            };
        }

        private Vector2 CalculateCardPlace(int cardCount)
        {
            return (OriginalSize - new Vector2(10f) * 2f) / new Vector2(cardCount, 1);
        }

        private Vector2 CalculateCardSize(int cardCount)
        {
            var cardPlace = CalculateCardPlace(cardCount) - new Vector2(10f) * 2;

            var dxdy = 200f / 279f;

            if (cardPlace.Y * dxdy > cardPlace.X)
                return new Vector2(cardPlace.X, cardPlace.X / dxdy);
            else
                return new Vector2(cardPlace.Y * dxdy, cardPlace.Y);
        }

        private Vector2 CalculateCardOffset(int cardCount)
        {
            var cardPlace = CalculateCardPlace(cardCount) - new Vector2(10f) * 2;
            var cardSize = CalculateCardSize(cardCount);

            return (cardPlace - cardSize) / 2f + new Vector2(20f) / 2f + new Vector2(20f) / 2f;
        }
    }
}
