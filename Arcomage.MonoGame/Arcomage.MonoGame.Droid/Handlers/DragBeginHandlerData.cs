using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragBeginHandlerData : HandlerData
    {
        public Vector2 Position { get; set; }

        public override bool Visit(HandlerVisitor handlerVisitor) => handlerVisitor.Visit(this);

        public override HandlerData Translate(Vector2 offset, Vector2 scale)
        {
            return new DragBeginHandlerData
            {
                GameTime = GameTime,
                Position = Position * scale + offset
            };
        }
    }
}