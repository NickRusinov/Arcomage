using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Animations
{
    public class IntervalAnimation : Animation
    {
        private TimeSpan currentInterval;

        public TimeSpan Interval { get; set; }

        public override void Animate(GameTime gameTime)
        {
            if (!IsEnabled)
                return;

            var elapsedInterval = gameTime.ElapsedGameTime;
            if (elapsedInterval > Interval - currentInterval)
                elapsedInterval = Interval - currentInterval;

            var delta = elapsedInterval.TotalMilliseconds / Interval.TotalMilliseconds;
            currentInterval += elapsedInterval;

            Animate((float)delta);

            IsEnabled = currentInterval < Interval;
        }

        public override void Reset()
        {
            currentInterval = TimeSpan.Zero;
            IsEnabled = true;
        }

        protected virtual void Animate(float delta) { }
    }
}