using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragBaseHandlerVisitor : HandlerVisitor
    {
        private readonly View view;

        private Vector2? initPosition;

        private Vector2? prevPosition;

        public DragBaseHandlerVisitor(View view)
        {
            this.view = view;
        }

        protected Vector2 InitPosition { get; private set; }
        
        protected Vector2 PrevPosition { get; private set; }

        public override bool Visit(DragBeginHandlerData handlerData)
        {
            if (prevPosition != null)
                return false;

            if (!view.Rectangle.Contains(handlerData.Position))
                return false;

            InitPosition = initPosition ?? view.Position;
            initPosition = InitPosition;
            prevPosition = handlerData.Position;
            return true;
        }

        public override bool Visit(DragEndHandlerData handlerData)
        {
            if (prevPosition == null)
                return false;

            PrevPosition = prevPosition.Value;
            prevPosition = null;
            return true;
        }

        public override bool Visit(DragMoveHandlerData handlerData)
        {
            if (prevPosition == null)
                return false;

            PrevPosition = prevPosition.Value;
            prevPosition = handlerData.Position;
            return true;
        }
    }
}