using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class SpriteElement : Element
    {
        public Texture2D Texture { get; set; }

        public SpriteEffects Effects { get; set; } = SpriteEffects.None;

        public override void Draw(SpriteBatch spriteBatch, Rectangle drawRectangle, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, 
                position: new Vector2(drawRectangle.X + PositionX * drawRectangle.Width, drawRectangle.Y + PositionY * drawRectangle.Height), 
                sourceRectangle: new Rectangle(0, 0, Texture.Width, Texture.Height), 
                color: Color.White, 
                rotation: Rotation, 
                origin: Vector2.Zero, 
                scale: new Vector2(drawRectangle.Width * SizeX / Texture.Width, drawRectangle.Height * SizeY / Texture.Height), 
                effects: Effects, 
                layerDepth: 0);
        }
    }
}
