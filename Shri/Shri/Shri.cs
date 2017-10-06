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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D txrPlayer;
        Sprite sprPlayer;

        public Shri()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
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
            sprPlayer = new Sprite(txrPlayer, new Vector2(100, 100));
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
            var keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                sprPlayer.Position.Y -= 10 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                sprPlayer.Position.X -= 10 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                sprPlayer.Position.Y += 10 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                sprPlayer.Position.X += 10 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
            }

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
