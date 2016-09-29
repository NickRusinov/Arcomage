using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid
{
    public class FontStorage
    {
        public static FontStorage Instance { get; } = new FontStorage();

        private readonly Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public void LoadFonts(ContentManager content)
        {
            fonts.Add("CardPriceFont", content.Load<SpriteFont>("CardPriceFont"));
        }

        public SpriteFont ResolveFont(string fontName)
        {
            SpriteFont font;
            if (!fonts.TryGetValue(fontName, out font))
                font = fonts["UndefinedFont"];

            return font;
        }
    }
}
