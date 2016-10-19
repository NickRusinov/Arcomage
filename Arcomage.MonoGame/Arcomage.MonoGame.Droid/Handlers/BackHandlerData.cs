using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class BackHandlerData : HandlerData
    {
        public override bool Visit(HandlerVisitor handlerVisitor) => handlerVisitor.Visit(this);
    }
}