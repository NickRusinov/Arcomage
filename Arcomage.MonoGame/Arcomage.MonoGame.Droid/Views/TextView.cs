using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class TextView : View
    {
        public SpriteFont Font { get; set; }

        public string Text { get; set; }

        public Color Color { get; set; }

        public override void Draw(Canvas canvas)
        {
            var measuredSize = Font.MeasureString(Text);
            var scale = new Vector2(Math.Min(SizeX / measuredSize.X, SizeY / measuredSize.Y));
            var offset = (Size - measuredSize * scale) / 2;

            canvas.DrawString(Font, Text,
                position: Position + offset,
                color: Color,
                rotation: 0,
                origin: Vector2.Zero,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0);
        }
    }
}