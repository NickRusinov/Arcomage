using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class SpriteView : View
    {
        public Texture2D Texture { get; set; }

        public float SourceX { get; set; }

        public float SourceY { get; set; }
        
        public Vector2 Source
        {
            get { return new Vector2(SourceX, SourceY); }
            set { SourceX = value.X; SourceY = value.Y; }
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Draw(Texture,
                position: Position,
                sourceRectangle: new Rectangle(0, 0, (int)(Texture.Width * SourceX / SizeX), (int)(Texture.Height * SourceY / SizeY)),
                color: Color.White,
                rotation: 0,
                origin: Vector2.Zero,
                scale: new Vector2(SizeX / Texture.Width, SizeY / Texture.Height),
                effects: 0,
                layerDepth: 0);
        }
    }
}
