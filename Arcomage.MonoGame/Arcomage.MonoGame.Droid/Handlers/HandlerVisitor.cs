using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class HandlerVisitor
    {
        public virtual bool Visit(DragBeginHandlerData handlerData) => false;

        public virtual bool Visit(DragEndHandlerData handlerData) => false;

        public virtual bool Visit(DragMoveHandlerData handlerData) => false;
    }
}