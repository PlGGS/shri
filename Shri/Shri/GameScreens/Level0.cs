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
        Texture2D txrWallTall;
        Sprite sprWallLeft;
        Sprite sprWallRight;
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
            
            txrPlayer = contentManager.GetTexture("Content\\Sprites\\bud.png");
            sprPlayer = new Sprite(txrPlayer,
                new Vector2((Shri.Instance.Window.ClientBounds.Width / 2),
                (Shri.Instance.Window.ClientBounds.Height / 2 + 200)),
                Color.White, new Vector2((txrPlayer.Width) / 2, (txrPlayer.Height) / 2),
                true, 250, 1.0f, 90)
            {
                Scale = new Vector2(0.2f, 0.2f) //Always make sure to set custom scale after instance creation
            };

            txrBackground = contentManager.GetTexture("Content\\Sprites\\baseLevel.png");

            txrWallTall = contentManager.GetTexture("Content\\Sprites\\black.png");
            sprWallLeft = new Sprite(txrWallTall, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f) //Always make sure to set custom scale after instance creation
            };
            sprWallRight = new Sprite(txrWallTall, new Vector2(Shri.Instance.Window.ClientBounds.Width - txrWallTall.Width, 0), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f) //Always make sure to set custom scale after instance creation
            };

            txrMediumFont = contentManager.GetTexture("Content\\Fonts\\medium-font.png");
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Content\\Fonts\\medium-font.fontmapping");

            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Green);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Console.WriteLine($"width: {(Shri.Instance.Window.ClientBounds.Width / 2)}");

            sprPlayer.Update(gameTime); //TODO reminder to always call sprite updates
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);
            fntMediumFont.DrawString(spriteBatch, "Hello, World", new Vector2(100, 100)); //TODO fix this
            //spriteBatch.Draw(txrBackground, Vector2.Zero, Color.White);
            sprPlayer.Draw(spriteBatch);
            sprWallLeft.Draw(spriteBatch);
            sprWallRight.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
