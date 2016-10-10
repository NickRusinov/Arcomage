using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Handlers;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Views
{
    public abstract class PanelView : View
    {
        protected PanelView(float originalSizeX, float originalSizeY)
        {
            OriginalSize = new Vector2(originalSizeX, originalSizeY);
        }

        protected List<View> Items { get; } = new List<View>();

        protected List<HandlerVisitor> HandlerVisitors { get; } = new List<HandlerVisitor>();

        protected Vector2 OriginalSize { get; }

        public override bool Handle(Handler handler, HandlerData handlerData)
        {
            var nestedHandler = handler.CreateNestedHandler(Position, Size / OriginalSize);
            
            return HandlerVisitors.Exists(hv => handler.Handle(hv, handlerData)) ||
                   Items.Exists(v => v.Handle(nestedHandler, handlerData));
        }

        public override void Draw(Canvas canvas)
        {
            var nestedCanvas = canvas.CreateNestedCanvas(Position, Size / OriginalSize);

            Items.ForEach(v => v.Draw(nestedCanvas));
        }
    }
}
