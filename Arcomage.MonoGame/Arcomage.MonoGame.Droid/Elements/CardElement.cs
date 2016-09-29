using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class CardElement : PanelElement
    {
        private readonly SpriteElement cardBackgroundElement = new SpriteElement
            { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 1.0f };

        private readonly SpriteElement cardImageElement = new SpriteElement
            { PositionX = 0.1f, PositionY = 0.1f, SizeX = 0.8f, SizeY = 0.4f };

        private readonly TextElement cardPriceElement = new TextElement
            { PositionX = 0.9f, PositionY = 0.9f, SizeX = 0.1f, SizeY = 0.1f };

        public CardElement(CardViewModel cardViewModel)
        {
            OnSetIndentifier(cardViewModel);
            OnSetResourcePrice(cardViewModel);
            OnSetResourceMode(cardViewModel);

            Elements = new List<Element> { cardBackgroundElement, cardImageElement, cardPriceElement };
        }

        private void OnSetIndentifier(CardViewModel cardViewModel)
        {
            cardImageElement.Texture = TextureStorage.Instance.ResolveTexture(cardViewModel.Identifier + "CardImage");
        }

        private void OnSetResourcePrice(CardViewModel cardViewModel)
        {
            cardPriceElement.Color = Color.White;
            cardPriceElement.Font = FontStorage.Instance.ResolveFont("CardPriceFont");
            cardPriceElement.Text = cardViewModel.ResourcePrice.ToString();
        }

        private void OnSetResourceMode(CardViewModel cardViewModel)
        {
            cardBackgroundElement.Texture = TextureStorage.Instance.ResolveTexture(cardViewModel.ResourceMode + "CardBackground");
        }
    }
}
