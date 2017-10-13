using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Shri
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Shri : Game
    {
        private static Shri _instance;
        public static Shri Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shri();
                }
                return _instance;
            }
        }
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameScreenManager _gameScreenManager;
        public GameScreenManager GameScreenManager
        {
            get
            {
                return _gameScreenManager;
            }
        }

        InputManager _inputManager;
        public InputManager InputManager
        {
            get
            {
                return _inputManager;
            }
        }


        ContentManager _contentManager;
        public ContentManager ContentManager
        {
            get
            {
                return _contentManager;
            }
        }

        public Shri()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            _inputManager = new InputManager();
            _gameScreenManager = new GameScreenManager();
            _contentManager = new ContentManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            _gameScreenManager.Push(new InitialGameScreen());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _contentManager.Prepare(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update();

            _gameScreenManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameScreenManager.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
