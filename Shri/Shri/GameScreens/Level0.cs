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
            _name = this.ToString();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            txrPlayer = contentManager.GetTexture("Content\\Sprites\\bud.png");
            sprPlayer = new Sprite(txrPlayer, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2 - txrPlayer.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2 - txrPlayer.Height / 2), Color.White, true);

            txrBackground = contentManager.GetTexture("Content\\Sprites\\baseLevel.png");

            txrMediumFont = contentManager.GetTexture("Content\\Fonts\\medium-font.png");
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Content\\Fonts\\medium-font.fontmapping");

            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Green);
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
            
            fntMediumFont.DrawString(spriteBatch, "Hello, World", new Vector2(0, 0)); //TODO fix this
            spriteBatch.Draw(txrBackground, Vector2.Zero, Color.White);
            sprPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
