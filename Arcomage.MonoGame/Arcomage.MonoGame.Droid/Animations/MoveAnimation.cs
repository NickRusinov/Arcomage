using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Animations
{
    public class MoveAnimation : IntervalAnimation
    {
        private readonly View view;

        private Vector2 offset;

        public MoveAnimation(View view)
        {
            this.view = view;
        }

        public Vector2 Position { get; set; }
        
        protected override void Animate(float delta)
        {
            view.Position += offset * delta;
        }

        public override void Reset()
        {
            offset = Position - view.Position;

            base.Reset();
        }
    }
}