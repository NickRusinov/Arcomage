using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class StrokeTextView : TextView
    {
        public Color StrokeColor { get; set; }

        public override void Draw(Canvas canvas)
        {
            var measuredSize = Font.MeasureString(Text);
            var scale = new Vector2(Math.Min(SizeX / measuredSize.X, SizeY / measuredSize.Y));
            var offset = (Size - measuredSize * scale) / 2;

            canvas.DrawString(Font, Text, 
                position: Position + offset + new Vector2(1, 1), 
                color: StrokeColor, 
                rotation: 0, 
                origin: Vector2.Zero, 
                scale: scale, 
                effects: SpriteEffects.None, 
                layerDepth: 0);

            canvas.DrawString(Font, Text,
                position: Position + offset + new Vector2(-1, 1),
                color: StrokeColor,
                rotation: 0,
                origin: Vector2.Zero,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0);

            canvas.DrawString(Font, Text,
                position: Position + offset + new Vector2(-1, -1),
                color: StrokeColor,
                rotation: 0,
                origin: Vector2.Zero,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0);

            canvas.DrawString(Font, Text,
                position: Position + offset + new Vector2(1, -1),
                color: StrokeColor,
                rotation: 0,
                origin: Vector2.Zero,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0);

            base.Draw(canvas);
        }
    }
}