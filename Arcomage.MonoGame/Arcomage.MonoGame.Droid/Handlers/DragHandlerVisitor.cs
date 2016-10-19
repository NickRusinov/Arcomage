using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Views;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragHandlerVisitor : DragBaseHandlerVisitor
    {
        private readonly View view;

        public DragHandlerVisitor(View view)
            : base(view)
        {
            this.view = view;
        }

        public override bool Visit(DragMoveHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled)
                view.Position += handlerData.Position - PrevPosition;

            return handled;
        }
    }
}