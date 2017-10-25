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
    public class Level0 : GameScreen
    {
        Texture2D txrPlayer;
        Sprite sprPlayer;
        Texture2D txrBackground;
        Texture2D txrMediumFont;
        FramedSprite sprMediumFont;
        Font fntMediumFont;

        public Level0()
        {
            _name = "Level0";
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            float txrScale = 0.2f;
            txrPlayer = contentManager.GetTexture("Content\\Sprites\\bud.png");
            sprPlayer = new Sprite(txrPlayer, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2 - (txrPlayer.Width * txrScale) / 2,
                Shri.Instance.Window.ClientBounds.Height / 2 - (txrPlayer.Height * txrScale ) / 2),
                Color.White, new Vector2(((txrPlayer.Width * txrScale) / 2), ((txrPlayer.Height * txrScale) / 2)),
                txrScale, true, 100);

            txrBackground = contentManager.GetTexture("Content\\Sprites\\baseLevel.png");

            txrMediumFont = contentManager.GetTexture("Content\\Fonts\\medium-font.png");
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Content\\Fonts\\medium-font.fontmapping");

            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Green);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            sprPlayer.Update(gameTime); //TODO reminder to always call sprite updates
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            fntMediumFont.DrawString(spriteBatch, "Hello, World", new Vector2(0, 0)); //TODO fix this
            spriteBatch.Draw(txrBackground, Vector2.Zero, Color.White);
            sprPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
