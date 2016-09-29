using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class ResourceElement : PanelElement
    {
        private readonly SpriteElement resourceBackgroundElement = new SpriteElement
            { PositionX = 0.025f, PositionY = 0.025f, SizeX = 0.95f, SizeY = 0.95f };

        private readonly SpriteElement resourceBorderImageElement = new SpriteElement
            { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 1.0f };

        private readonly SpriteElement resourceImageElement = new SpriteElement
            { PositionX = 0.25f, PositionY = 0.25f, SizeX = 0.5f, SizeY= 0.5f };

        private readonly TextElement resourceDeltaElement = new TextElement
            { PositionX = 0.2f, PositionY = 0.2f };

        private readonly TextElement resourceValueElement = new TextElement
            { PositionX = 0.8f, PositionY = 0.8f };

        public ResourceElement(ResourceViewModel resourceViewModel, bool flipped)
        {
            resourceBackgroundElement.Texture = TextureStorage.Instance.ResolveTexture(resourceViewModel.Identifier + "ResourceBackground");

            resourceBorderImageElement.Texture = TextureStorage.Instance.ResolveTexture(resourceViewModel.Identifier + "ResourceBorderImage");

            resourceImageElement.Texture = TextureStorage.Instance.ResolveTexture(resourceViewModel.Identifier + "ResourceImage");
            resourceImageElement.Effects = flipped ? SpriteEffects.FlipHorizontally : resourceImageElement.Effects;

            resourceDeltaElement.Font = FontStorage.Instance.ResolveFont("ResourceDeltaFont");
            resourceDeltaElement.Color = Color.Black;
            resourceDeltaElement.Text = "+" + resourceViewModel.Delta.ToString();
            resourceDeltaElement.PositionX = flipped ? 0.8f : resourceDeltaElement.PositionX;

            resourceValueElement.Font = FontStorage.Instance.ResolveFont("ResourceValueFont");
            resourceValueElement.Color = Color.Black;
            resourceValueElement.Text = resourceViewModel.Value.ToString();
            resourceValueElement.PositionX = flipped ? 0.2f : resourceValueElement.PositionX;

            Elements = new List<Element> { resourceBackgroundElement, resourceBorderImageElement, resourceImageElement, resourceDeltaElement, resourceValueElement };
        }
    }
}
