using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public abstract class HandlerData
    {
        public GameTime GameTime { get; set; }

        public abstract bool Visit(HandlerVisitor handlerVisitor);

        public virtual HandlerData Translate(Vector2 offset, Vector2 scale) => this;
    }
}