using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Animations;
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

        public List<View> Items { get; } = new List<View>();

        public List<Animation> Animations { get; } = new List<Animation>();

        public List<HandlerVisitor> HandlerVisitors { get; } = new List<HandlerVisitor>();

        public Vector2 OriginalSize { get; }

        public override void Animate(GameTime gameTime)
        {
            Animations.ForEach(a => a.Animate(gameTime));

            Items.ForEach(v => v.Animate(gameTime));
        }

        public override bool Handle(Handler handler, HandlerData handlerData)
        {
            HandlerVisitors.ForEach(hv => handler.Handle(hv, handlerData));

            var nestedHandler = handler.CreateNestedHandler(Position, Size / OriginalSize);

            return Items.Exists(v => v.Handle(nestedHandler, handlerData));
        }

        public override void Draw(Canvas canvas)
        {
            var nestedCanvas = canvas.CreateNestedCanvas(Position, Size / OriginalSize);

            Items.ForEach(v => v.Draw(nestedCanvas));
        }
    }
}
