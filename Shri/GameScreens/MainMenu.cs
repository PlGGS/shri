using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shri.Sprites;
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
        SprTitle sprTitle;

        public MainMenu()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            base.LoadContent(contentManager, graphicsDevice);

            txrTitle = contentManager.GetTexture("Shri/Content/Images/mainMenu.png", graphicsDevice);
            sprTitle = new SprTitle(txrTitle, Vector2.Zero, Color.White, Vector2.Zero, true, 0, 1.0f);
            Shri.Instance.SoundManager.PlaySound("Music");
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
