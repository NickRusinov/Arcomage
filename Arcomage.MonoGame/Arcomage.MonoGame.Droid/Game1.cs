using System.Collections.Generic;
using Arcomage.MonoGame.Droid.Elements;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arcomage.MonoGame.Droid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private readonly List<Element> elementCollection = new List<Element>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureStorage.Instance.LoadTextures(Content);
            FontStorage.Instance.LoadFonts(Content);

            var cardViewModel = new CardViewModel { Identifier = "Undefined", ResourceMode = "Gems", ResourcePrice = 5 };
            var bricksViewModel = new ResourceViewModel { Identifier = "Bricks", Delta = 2, Value = 5 };
            var gemsViewModel = new ResourceViewModel { Identifier = "Gems", Delta = 2, Value = 5 };
            var recruitsViewModel = new ResourceViewModel { Identifier = "Recruits", Delta = 2, Value = 5 };
            var resourcesViewModel = new ResourcesViewModel { Bricks = bricksViewModel, Gems = gemsViewModel, Recruits = recruitsViewModel };

            var ge = new GameElement { PositionX = 0.0f, PositionY = 0.0f, SizeX = 1.0f, SizeY = 1.0f };
            var re1 = new ResourcesElement(resourcesViewModel, false) { PositionX = 0.005f, PositionY = 0.005f, SizeX = 0.16f, SizeY = 0.6f };
            var re2 = new ResourcesElement(resourcesViewModel, true) { PositionX = 0.835f, PositionY = 0.005f, SizeX = 0.16f, SizeY = 0.6f };
            var ce1 = new CardElement(cardViewModel) { PositionX = 0.2f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            var ce2 = new CardElement(cardViewModel) { PositionX = 0.3f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            var ce3 = new CardElement(cardViewModel) { PositionX = 0.4f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            var ce4 = new CardElement(cardViewModel) { PositionX = 0.5f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            var ce5 = new CardElement(cardViewModel) { PositionX = 0.6f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            var ce6 = new CardElement(cardViewModel) { PositionX = 0.7f, PositionY = 0.7f, SizeX = 0.1f, SizeY = 0.3f };
            elementCollection.AddRange(new Element[] { ge, re1, re2, ce1, ce2, ce3, ce4, ce5, ce6 });

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
         
            var drawRectangle = new Rectangle(0, 0, spriteBatch.GraphicsDevice.DisplayMode.Width, spriteBatch.GraphicsDevice.DisplayMode.Height);   
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            elementCollection.ForEach(e => e.Draw(spriteBatch, drawRectangle, gameTime));
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
