using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class TextElement : Element
    {
        public string Text { get; set; }

        public Color Color { get; set; }

        public SpriteFont Font { get; set; }
        
        public override void Draw(SpriteBatch spriteBatch, Rectangle drawRectangle, GameTime gameTime)
        {
            spriteBatch.DrawString(Font, Text, 
                position: new Vector2(drawRectangle.X + PositionX * drawRectangle.Width, drawRectangle.Y + PositionY * drawRectangle.Height),
                color: Color,
                rotation: Rotation,
                origin: Vector2.Zero,
                scale: Vector2.One,
                effects: SpriteEffects.None,
                layerDepth: 0);
        }
    }
}
