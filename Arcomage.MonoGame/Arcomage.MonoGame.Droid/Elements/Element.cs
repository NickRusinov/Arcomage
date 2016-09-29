using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Elements
{
    public abstract class Element
    {
        public float PositionX { get; set; } = 0;

        public float PositionY { get; set; } = 0;

        public float SizeX { get; set; } = 1;

        public float SizeY { get; set; } = 1;

        public float Rotation { get; set; } = 0;

        public abstract void Draw(SpriteBatch spriteBatch, Rectangle drawRectangle, GameTime gameTime);
    }
}
