using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragHandlerVisitor : HandlerVisitor
    {
        private readonly View view;

        private Vector2? prevPosition;

        public DragHandlerVisitor(View view)
        {
            this.view = view;
        }

        public override bool Visit(DragBeginHandlerData handlerData)
        {
            if (prevPosition != null)
                return false;

            if (!view.Rectangle.Contains(handlerData.Position))
                return false;

            prevPosition = handlerData.Position;
            return true;
        }

        public override bool Visit(DragEndHandlerData handlerData)
        {
            if (prevPosition == null)
                return false;

            prevPosition = null;
            return true;
        }

        public override bool Visit(DragMoveHandlerData handlerData)
        {
            if (prevPosition == null)
                return false;

            view.Position += handlerData.Position - prevPosition.Value;
            prevPosition = handlerData.Position;
            return true;
        }
    }
}