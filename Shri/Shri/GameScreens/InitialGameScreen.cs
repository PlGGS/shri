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
        Texture2D txrBackground;

        public InitialGameScreen()
        {
            _name = this.ToString();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            txrBackground = contentManager.GetTexture("Content\\Sprites\\mainMenu.png");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            spriteBatch.Draw(txrBackground, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}
