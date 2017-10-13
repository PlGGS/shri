using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class InitialGameScreen : GameScreen
    {
        Texture2D txrPlayer;
        Sprite sprPlayer;

        public InitialGameScreen()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            txrPlayer = contentManager.GetTexture("Content\\Sprites\\bud.png");
            sprPlayer = new Sprite(txrPlayer, new Vector2(100, 100), Color.White, true);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Shri.Instance.InputManager.Pressed(Input.Back))
            {
                Shri.Instance.Exit();
            }

            sprPlayer.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            spriteBatch.Draw(txrPlayer, Vector2.Zero, Color.White);
            sprPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
