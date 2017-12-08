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
    public class Level1 : Level
    {
        public SprFill sprFillLeft;
        public SprFill sprFillRight;
        
        public Level1()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            sprFillLeft = new SprFill(txrFillRed, new Vector2(Shri.Instance.Window.ClientBounds.Width / 4, Shri.Instance.Window.ClientBounds.Height / 2), new Circle(new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), (txrPlayerBlue.Width / 2)), Color.White, new Vector2(txrFillBlue.Width / 2, txrFillBlue.Height / 2), Color.Blue)
            {
                Scale = new Vector2(0.5f, 0.5f)
            };
            sprFillLeft.Circle.Radius *= sprFillLeft.Scale.X;

            sprFillRight = new SprFill(txrFillRed, new Vector2((Shri.Instance.Window.ClientBounds.Width / 4) * 3, Shri.Instance.Window.ClientBounds.Height / 2), new Circle(new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), (txrPlayerBlue.Width / 2)), Color.White, new Vector2(txrFillBlue.Width / 2, txrFillBlue.Height / 2), Color.Red)
            {
                Scale = new Vector2(0.2f, 0.2f)
            };
            sprFillRight.Circle.Radius *= sprFillRight.Scale.X;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            sprFillLeft.Update(gameTime);
            sprFillRight.Update(gameTime);

            if (sprFillLeft.Filled && sprFillRight.Filled)
            {
                sprExit.Open = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            if (sprFillLeft.Filled == false)
            {
                sprFillLeft.Texture = txrFillBlue;
                sprFillLeft.Draw(spriteBatch);
            }
            else
            {
                sprFillLeft.Texture = txrFilled;
                sprFillLeft.Draw(spriteBatch);
            }

            if (sprFillRight.Filled == false)
            {
                sprFillRight.Texture = txrFillRed;
                sprFillRight.Draw(spriteBatch);
            }
            else
            {
                sprFillRight.Texture = txrFilled;
                sprFillRight.Draw(spriteBatch);
            }

            sprPlayer.Draw(spriteBatch);
            //spriteBatch.Draw(txrWhite, sprPlayer.Bounds, Color.Green); //TODO add debug bounds drawing input

            spriteBatch.End();
        }
    }
}
