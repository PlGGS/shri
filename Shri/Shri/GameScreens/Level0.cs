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
    public class Level0 : Level
    {
        public SprFill sprFill;

        Texture2D txrMediumFont;
        FramedSprite sprMediumFont;
        Font fntMediumFont;

        public Level0()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            sprFill = new SprFill(txrFillRed, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), new Circle(new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), (txrPlayerBlue.Width / 2)), Color.White, new Vector2(txrFillBlue.Width / 2, txrFillBlue.Height / 2), Color.Red)
            {
                Scale = new Vector2(0.1f, 0.1f)
            };
            sprFill.Circle.Radius = sprFill.Circle.Radius * sprFill.Scale.X;

            txrMediumFont = contentManager.GetTexture("Content\\Fonts\\medium-font.png");
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Content\\Fonts\\medium-font.fontmapping");

            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Green);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            sprFill.Update(gameTime);

            if (sprFill.Filled)
            {
                sprExit.Open = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            fntMediumFont.DrawString(spriteBatch, "Hello, World", new Vector2(100, 100)); //TODO fix this

            if (sprFill.Filled == false)
            {
                sprFill.Texture = txrFillRed;
                sprFill.Draw(spriteBatch);
            }
            else
            {
                sprFill.Texture = txrFilled;
                sprFill.Draw(spriteBatch);
            }

            sprPlayer.Draw(spriteBatch);
            //spriteBatch.Draw(txrWhite, sprPlayer.Bounds, Color.Green);

            spriteBatch.End();
        }
    }
}
