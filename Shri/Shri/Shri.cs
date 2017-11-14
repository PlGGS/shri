using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shri.Managers;
using System.Collections.Generic;
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

        SoundManager _soundManager;
        public SoundManager SoundManager
        {
            get
            {
                return _soundManager;
            }
        }

        public Shri()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            _gameScreenManager = new GameScreenManager();
            _inputManager = new InputManager();
            _contentManager = new ContentManager();
            _soundManager = new SoundManager(new List<SoundFX>
            {
                new SoundFX {Key = "Fill", FileName = "Content\\Audio\\fill.wav", DefaultPitch = 1, DefaultVolume = 1},
                new SoundFX {Key = "NoFill", FileName = "Content\\Audio\\noFill.wav", DefaultPitch = 1, DefaultVolume = 1},
                new SoundFX {Key = "Open", FileName = "Content\\Audio\\open.wav", DefaultPitch = 1, DefaultVolume = 1},
                new SoundFX {Key = "Music", FileName = "Content\\Audio\\music.wav", DefaultPitch = 1, DefaultVolume = 1}
            });
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

            _gameScreenManager.Push(new MainMenu());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _contentManager.Prepare(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _soundManager.LoadContent(ContentManager);
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
            GraphicsDevice.Clear(Color.White); //This makes sure we're not still rendering old screens when we shift to a new one

            _gameScreenManager.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
