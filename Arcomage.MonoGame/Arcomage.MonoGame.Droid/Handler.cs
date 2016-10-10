using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Handlers;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid
{
    public class Handler
    {
        private readonly Vector2 handlerPosition;

        private readonly Vector2 handlerScale;

        public Handler(Vector2 handlerPosition, Vector2 handlerScale)
        {
            this.handlerPosition = handlerPosition;
            this.handlerScale = handlerScale;
        }

        public bool Handle(HandlerVisitor handlerVisitor, HandlerData handlerData)
        {
            return handlerData.Translate(handlerPosition, handlerScale).Visit(handlerVisitor);
        }

        public Handler CreateNestedHandler(Vector2 position, Vector2 scale)
        {
            return new Handler(handlerPosition - position / handlerScale, handlerScale / scale);
        }
    }
}
