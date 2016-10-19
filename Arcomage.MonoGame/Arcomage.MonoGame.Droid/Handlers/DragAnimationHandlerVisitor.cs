using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Animations;
using Arcomage.MonoGame.Droid.Views;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragAnimationHandlerVisitor : DragBaseHandlerVisitor
    {
        private readonly MoveAnimation moveAnimation;

        public DragAnimationHandlerVisitor(View view, MoveAnimation moveAnimation)
            : base(view)
        {
            this.moveAnimation = moveAnimation;
        }

        public override bool Visit(DragBeginHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled)
                moveAnimation.IsEnabled = false;

            return handled;
        }

        public override bool Visit(DragEndHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled)
            {
                moveAnimation.Position = InitPosition;
                moveAnimation.Interval = TimeSpan.FromSeconds(1);
                moveAnimation.Reset();
            }

            return handled;
        }
    }
}