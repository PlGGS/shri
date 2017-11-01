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
    public class Level0 : GameScreen
    {
        Texture2D txrPlayer;
        Texture2D txrBackground;
        Texture2D txrBlack;
        Texture2D txrWhite;
        Texture2D txrFill;

        public Sprite sprPlayer;
        protected List<Sprite> _walls = new List<Sprite>();
        public List<Sprite> Walls
        {
            get
            {
                return _walls;
            }
        }
        public Sprite sprWallLeft;
        public Sprite sprWallRight;
        public Sprite sprWallTop;
        public Sprite sprWallBottom;
        public Sprite sprFill;
        public Sprite sprEntrance;
        public Sprite sprExit; //TODO create individual Sprite classes for fill and exit

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
            
            txrPlayer = contentManager.GetTexture("Content\\Images\\bud.png");
            sprPlayer = new SprPlayer(txrPlayer,
                new Vector2((Shri.Instance.Window.ClientBounds.Width / 2),
                (Shri.Instance.Window.ClientBounds.Height / 2 + 170)),
                Color.White, new Vector2((txrPlayer.Width) / 2, (txrPlayer.Height) / 2),
                true, 250, 1.0f, 90)
            {
                Scale = new Vector2(0.2f, 0.2f) //Always make sure to set custom scale after instance creation
            };

            txrBackground = contentManager.GetTexture("Content\\Images\\baseLevel.png");
            txrBlack = contentManager.GetTexture("Content\\Images\\black.png");
            txrWhite = contentManager.GetTexture("Content\\Images\\white.png");
            txrFill = contentManager.GetTexture("Content\\Images\\fill.png");

            sprWallLeft = new Sprite(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f) //Always make sure to set custom scale after instance creation
            };
            sprWallRight = new Sprite(txrBlack, new Vector2(Shri.Instance.Window.ClientBounds.Width - txrBlack.Width, 0), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f) //Always make sure to set custom scale after instance creation
            };
            sprWallTop = new Sprite(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f) //Always make sure to set custom scale after instance creation
            };
            sprWallBottom = new Sprite(txrBlack, new Vector2(0, Shri.Instance.Window.ClientBounds.Height - txrBlack.Height), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f) //Always make sure to set custom scale after instance creation
            };
            sprFill = new SprFill(txrFill, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height / 2), Color.White, new Vector2(txrFill.Width / 2, txrFill.Height / 2))
            {
                Scale = new Vector2(0.1f, 0.1f) //Always make sure to set custom scale after instance creation
            };
            sprExit = new SprExit(txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, 0), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1f) //Always make sure to set custom scale after instance creation
            };
            sprEntrance = new SprExit(txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, 0), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1f) //Always make sure to set custom scale after instance creation
            };

            _walls.Add(sprWallLeft);
            _walls.Add(sprWallRight);
            _walls.Add(sprWallTop);
            _walls.Add(sprWallBottom);

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
            sprFill.Draw(spriteBatch);
            sprPlayer.Draw(spriteBatch);
            foreach (Sprite wall in _walls)
            {
                wall.Draw(spriteBatch);
            }
            sprExit.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
