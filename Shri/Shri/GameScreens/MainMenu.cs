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
    public class MainMenu : GameScreen
    {
        Texture2D txrTitle;
        Sprite sprTitle;

        public MainMenu()
        {
            _name = "MainMenu";
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            txrTitle = contentManager.GetTexture("Content\\Sprites\\mainMenu.png");
            sprTitle = new Sprite(txrTitle, Vector2.Zero, Color.White, Vector2.Zero, true, 0, 1.0f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            sprTitle.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            sprTitle.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
