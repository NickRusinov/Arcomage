using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid
{
    public class TextureStorage
    {
        public static TextureStorage Instance { get; } = new TextureStorage();

        private readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public void LoadTextures(ContentManager content)
        {
            textures.Add("GameBackground", content.Load<Texture2D>("GameBackground"));
            textures.Add("GameCardsBackground", content.Load<Texture2D>("GameCardsBackground"));
            textures.Add("GameBorderImage", content.Load<Texture2D>("GameBorderImage"));

            textures.Add("BricksResourceBackground", content.Load<Texture2D>("BricksResourceBackground"));
            textures.Add("BricksResourceBorderImage", content.Load<Texture2D>("BricksResourceBorderImage"));
            textures.Add("BricksResourceImage", content.Load<Texture2D>("BricksResourceImage"));

            textures.Add("GemsResourceBackground", content.Load<Texture2D>("GemsResourceBackground"));
            textures.Add("GemsResourceBorderImage", content.Load<Texture2D>("GemsResourceBorderImage"));
            textures.Add("GemsResourceImage", content.Load<Texture2D>("GemsResourceImage"));

            textures.Add("RecruitsResourceBackground", content.Load<Texture2D>("RecruitsResourceBackground"));
            textures.Add("RecruitsResourceBorderImage", content.Load<Texture2D>("RecruitsResourceBorderImage"));
            textures.Add("RecruitsResourceImage", content.Load<Texture2D>("RecruitsResourceImage"));

            textures.Add("BricksCardBackground", content.Load<Texture2D>("BricksCardBackground"));
            textures.Add("GemsCardBackground", content.Load<Texture2D>("GemsCardBackground"));
            textures.Add("RecruitsCardBackground", content.Load<Texture2D>("RecruitsCardBackground"));

            textures.Add("UndefinedCardImage", content.Load<Texture2D>("UndefinedCardImage"));

            textures.Add("UndefinedTexture", content.Load<Texture2D>("UndefinedTexture"));
        }

        public Texture2D ResolveTexture(string textureName)
        {
            Texture2D texture;
            if (!textures.TryGetValue(textureName, out texture))
                texture = textures["UndefinedTexture"];

            return texture;
        }
    }
}
