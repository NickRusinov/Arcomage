using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.MonoGame.Droid.Commands;
using Arcomage.MonoGame.Droid.Handlers;
using Arcomage.MonoGame.Droid.ViewModels;
using Arcomage.MonoGame.Droid.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using static Microsoft.Xna.Framework.DisplayOrientation;
using static Microsoft.Xna.Framework.Input.Touch.GestureType;
using static Microsoft.Xna.Framework.Input.Touch.TouchLocationState;

namespace Arcomage.MonoGame.Droid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ArcomageGame : Game
    {
        private GraphicsDeviceManager graphics;
        
        private SpriteBatch spriteBatch;

        private Canvas canvas;

        private Handler handler;

        private PageView view;
        
        private Vector2? dragPosition;
        
        public ArcomageGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = LandscapeLeft | LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            TouchPanel.EnabledGestures = Tap | DoubleTap | FreeDrag | HorizontalDrag | VerticalDrag | DragComplete;

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";

            view = new PageView();

            var menuViewModel = new MenuViewModel
            {
                PlayButton = new ButtonViewModel
                {
                    Identifier = "Play",
                    Command = new PlayCommand(Content, view)
                },
                SettingsButton = new ButtonViewModel
                {
                    Identifier = "Settings",
                    Command = new SettingsCommand()
                },
                ExitButton = new ButtonViewModel
                {
                    Identifier = "Exit",
                    Command = new ExitCommand(this)
                }
            };

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            canvas = new Canvas(spriteBatch, Vector2.Zero, Vector2.One);
            handler = new Handler(Vector2.Zero, Vector2.One);
            view.View = new MenuView(Content, menuViewModel)
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720
            };

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
            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();

                if (gesture.GestureType == Tap)
                {
                    view.Handle(handler, new ClickHandlerData { GameTime = gameTime, Position = gesture.Position });
                }

                if (gesture.GestureType == DoubleTap)
                {
                    view.Handle(handler, new DoubleClickHandlerData { GameTime = gameTime, Position = gesture.Position });
                }

                if (dragPosition == null &&
                    (gesture.GestureType == HorizontalDrag ||
                     gesture.GestureType == VerticalDrag ||
                     gesture.GestureType == FreeDrag))
                {
                    view.Handle(handler, new DragBeginHandlerData { GameTime = gameTime, Position = gesture.Position });
                    dragPosition = gesture.Position;
                }

                if (dragPosition != null &&
                    (gesture.GestureType == HorizontalDrag ||
                     gesture.GestureType == VerticalDrag ||
                     gesture.GestureType == FreeDrag))
                {
                    view.Handle(handler, new DragMoveHandlerData { GameTime = gameTime, Position = gesture.Position });
                    dragPosition = gesture.Position;
                }

                if (dragPosition != null &&
                    gesture.GestureType == DragComplete)
                {
                    view.Handle(handler, new DragEndHandlerData { GameTime = gameTime, Position = dragPosition.Value });
                    dragPosition = null;
                }
            }

            foreach (var touch in TouchPanel.GetState())
            {
                if (touch.State == Pressed)
                {
                    view.Handle(handler, new PressDownHandlerData { GameTime = gameTime, Position = touch.Position });
                }

                if (touch.State == Released)
                {
                    view.Handle(handler, new PressUpHandlerData { GameTime = gameTime, Position = touch.Position });
                }
            }

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
            
            view.Animate(gameTime);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            view.Draw(canvas);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
