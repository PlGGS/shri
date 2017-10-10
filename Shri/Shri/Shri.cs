using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Shri
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Shri : Game
    {
        private static Shri instance;
        public static Shri Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shri();
                }
                return instance;
            }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D txrPlayer;
        Sprite sprPlayer;

        InputManager inputManager;
        public InputManager InputManager
        {
            get
            {
                return inputManager;
            }
        }

        public Shri()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            inputManager = new InputManager();
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            txrPlayer = Texture2D.FromStream(GraphicsDevice, File.OpenRead("Content\\bud.png"));
            sprPlayer = new Sprite(txrPlayer, new Vector2(100, 100), true);
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
            inputManager.Update();

            if (inputManager.Pressed(Input.Up, Input.Down))
            {
                Shri.Instance.Exit();
            }

            if (inputManager.Pressed(Input.Back))
            {
                Exit();
            }
            
            sprPlayer.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            spriteBatch.Draw(txrPlayer, Vector2.Zero, Color.White);
            sprPlayer.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
