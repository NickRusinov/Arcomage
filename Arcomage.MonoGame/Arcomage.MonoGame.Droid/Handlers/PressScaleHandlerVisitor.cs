using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class PressScaleHandlerVisitor : HandlerVisitor
    {
        private readonly View view;

        private readonly Vector2 size;

        private Vector2? initialPosition;

        private Vector2? initialSize;

        public PressScaleHandlerVisitor(View view, Vector2 size)
        {
            this.view = view;
            this.size = size;
        }

        public override bool Visit(PressDownHandlerData handlerData)
        {
            if (!view.Rectangle.Contains(handlerData.Position))
                return false;

            initialPosition = view.Position;
            initialSize = view.Size;
            view.Position += (view.Size - size) / 2f;
            view.Size = size;
            return true;
        }

        public override bool Visit(PressUpHandlerData handlerData)
        {
            if (initialPosition == null || initialSize == null)
                return false;

            view.Position = initialPosition.Value;
            view.Size = initialSize.Value;
            initialPosition = null;
            initialSize = null;
            return true;
        }
    }
}