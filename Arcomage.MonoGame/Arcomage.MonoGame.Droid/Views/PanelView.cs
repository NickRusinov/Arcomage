using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.MonoGame.Droid.Views
{
    public class PanelView : View
    {
        public IList<View> Items { get; set; } = new List<View>();

        public override void Draw(Canvas canvas)
        {
            var nestedCanvas = canvas.CreateNestedCanvas(Rectangle);

            foreach (var item in Items)
                item.Draw(nestedCanvas);
        }
    }
}
