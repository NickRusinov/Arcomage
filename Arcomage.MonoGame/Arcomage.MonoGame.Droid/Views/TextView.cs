using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Arcomage.MonoGame.Droid.Views.HorizontalAlign;
using static Arcomage.MonoGame.Droid.Views.VerticalAlign;

namespace Arcomage.MonoGame.Droid.Views
{
    public class TextView : View
    {
        public SpriteFont Font { get; set; }

        public string Text { get; set; }

        public Color Color { get; set; } = Color.Black;

        public float MaxScale { get; set; } = 1f;

        public HorizontalAlign HorizontalAlign { get; set; } = HorizontalAlign.Center;

        public VerticalAlign VerticalAlign { get; set; } = VerticalAlign.Center;

        public override void Draw(Canvas canvas)
        {
            var measuredSize = Font.MeasureString(Text);
            var scale = new Vector2(Math.Min(MaxScale, Math.Min(SizeX / measuredSize.X, SizeY / measuredSize.Y)));
            var offset = (Size - measuredSize * scale) * CalculateAlign();

            canvas.DrawString(Font, Text,
                position: Position + offset,
                color: Color,
                rotation: 0,
                origin: Vector2.Zero,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0);
        }

        private Vector2 CalculateAlign()
        {
            return new Vector2(
                HorizontalAlign == Left ? 0.0f : HorizontalAlign == Right ? 1.0f : 0.5f,
                VerticalAlign == Top ? 0.0f : VerticalAlign == Bottom ? 1.0f : 0.5f);
        }
    }
}