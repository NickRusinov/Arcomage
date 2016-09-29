using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class GameElement : PanelElement
    {
        private readonly SpriteElement gameBackgroundElement = new SpriteElement
            { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 0.625f };

        private readonly SpriteElement gameCardsBackgroundElement = new SpriteElement
            { PositionX = 0.0f, PositionY = 0.625f, SizeX = 1.0f, SizeY = 0.375f };

        private readonly SpriteElement gameBorderImageElement = new SpriteElement
            { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 1.0f };

        public GameElement()
        {
            gameBackgroundElement.Texture = TextureStorage.Instance.ResolveTexture("GameBackground");
            gameCardsBackgroundElement.Texture = TextureStorage.Instance.ResolveTexture("GameCardsBackground");
            gameBorderImageElement.Texture = TextureStorage.Instance.ResolveTexture("GameBorderImage");

            Elements = new List<Element> { gameBackgroundElement, gameCardsBackgroundElement, gameBorderImageElement };
        }
    }
}
