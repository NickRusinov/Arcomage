using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid.Views
{
    public class CardSetView : View<CardSetViewModel>
    {
        public CardSetView(ContentManager contentManager, CardSetViewModel cardSetViewModel)
            : base(cardSetViewModel, 1270, 315)
        {
            if (cardSetViewModel.CardCollection.Count != 0)
            {
                var index = 0;
                var cardOffset = CalculateCardOffset(cardSetViewModel.CardCollection.Count);
                var cardPlace = CalculateCardPlace(cardSetViewModel.CardCollection.Count);
                var cardSize = CalculateCardSize(cardSetViewModel.CardCollection.Count);

                foreach (var cardViewModel in cardSetViewModel.CardCollection)
                {
                    var cardView = new CardView(contentManager, cardViewModel);
                    InitializeCard(cardView, cardOffset, cardPlace, cardSize, index++);
                }
            }
        }

        private void InitializeCard(CardView cardView, Vector2 cardOffset, Vector2 cardDelta, Vector2 cardSize, int index)
        {
            cardView.Position = cardOffset + new Vector2(cardDelta.X, 0) * index;
            cardView.Size = cardSize;

            Items.Add(cardView);
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
