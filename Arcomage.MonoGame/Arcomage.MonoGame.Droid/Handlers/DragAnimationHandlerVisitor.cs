using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Animations;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DragAnimationHandlerVisitor : DragHandlerVisitor
    {
        private readonly View view;

        private readonly MoveAnimation moveAnimation;

        private Vector2? initialPosition;

        public DragAnimationHandlerVisitor(View view, MoveAnimation moveAnimation)
            : base(view)
        {
            this.view = view;
            this.moveAnimation = moveAnimation;
        }

        public override bool Visit(DragBeginHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled)
            {
                moveAnimation.IsEnabled = false;
                initialPosition = initialPosition ?? view.Position;
            }

            return handled;
        }

        public override bool Visit(DragEndHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled && initialPosition != null)
            {
                moveAnimation.Position = initialPosition.Value;
                moveAnimation.Interval = TimeSpan.FromSeconds(1);
                moveAnimation.Reset();
            }

            return handled;
        }
    }
}