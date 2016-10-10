using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Animations
{
    public abstract class Animation
    {
        public bool IsEnabled { get; set; }

        public abstract void Animate(GameTime gameTime);

        public abstract void Reset();
    }
}