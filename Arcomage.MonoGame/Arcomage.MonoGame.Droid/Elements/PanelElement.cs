using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Elements
{
    public class PanelElement : Element
    {
        public IReadOnlyCollection<Element> Elements { get; set; }

        public override void Draw(SpriteBatch spriteBatch, Rectangle drawRectangle, GameTime gameTime)
        {
            var innerDrawRectangle = new Rectangle(
                (int)(drawRectangle.X + drawRectangle.Width * PositionX), 
                (int)(drawRectangle.Y + drawRectangle.Height * PositionY), 
                (int)(drawRectangle.Width * SizeX), 
                (int)(drawRectangle.Height * SizeY));

            foreach (var element in Elements)
                element.Draw(spriteBatch, innerDrawRectangle, gameTime);
        }
    }
}
