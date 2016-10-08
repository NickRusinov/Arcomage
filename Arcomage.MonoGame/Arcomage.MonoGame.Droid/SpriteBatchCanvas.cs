using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid
{
    public class SpriteBatchCanvas : Canvas
    {
        private readonly SpriteBatch spriteBatch;

        private readonly Vector2 spritePosition;

        private readonly Vector2 spriteScale;

        public SpriteBatchCanvas(SpriteBatch spriteBatch, Vector2 spritePosition, Vector2 spriteScale)
        {
            this.spriteBatch = spriteBatch;
            this.spritePosition = spritePosition;
            this.spriteScale = spriteScale;
        }

        public override void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, position + spritePosition, sourceRectangle, color, rotation, origin, scale * spriteScale, effects, layerDepth);
        }

        public override Canvas CreateNestedCanvas(Rectangle nestedRectangle)
        {
            return new SpriteBatchCanvas(spriteBatch, spritePosition + nestedRectangle.Location.ToVector2(), spriteScale);
        }
    }
}
