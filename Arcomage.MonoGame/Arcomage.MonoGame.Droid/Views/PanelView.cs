using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Views
{
    public class PanelView : View
    {
        public PanelView(float originalSizeX, float originalSizeY)
        {
            OriginalSizeY = originalSizeY;
            OriginalSizeX = originalSizeX;
        }

        public IList<View> Items { get; } = new List<View>();

        public float OriginalSizeX { get; }

        public float OriginalSizeY { get; }

        public Vector2 OriginalSize => new Vector2(OriginalSizeX, OriginalSizeY);

        public override void Draw(Canvas canvas)
        {
            var nestedCanvas = canvas.CreateNestedCanvas(Position, Size / OriginalSize);

            foreach (var item in Items)
                item.Draw(nestedCanvas);
        }
    }
}
