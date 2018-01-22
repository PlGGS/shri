using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shri.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public abstract class Level : GameScreen
    {
        public Texture2D txrPlayerBlue;
        public Texture2D txrPlayerYellow;
        public Texture2D txrPlayerRed;
        public Texture2D txrFillBlue;
        public Texture2D txrFillYellow;
        public Texture2D txrFillRed;
        public Texture2D txrFilled;
        public Texture2D txrBlack;
        public Texture2D txrWhite;
        public Texture2D txrMediumFont;
       
        public SprPlayer sprPlayer;
        protected List<SprWall> _walls = new List<SprWall>();
        public List<SprWall> Walls
        {
            get
            {
                return _walls;
            }
        }
        public SprWall sprWallLeft;
        public SprWall sprWallRight;
        public SprWall sprWallTop;
        public SprWall sprWallBottom;
        public SprEntrance sprEntrance;
        public SprExit sprExit;
        public FramedSprite sprMediumFont;

        public Font fntMediumFont;

        public override void LoadContent(ContentManager contentManager)
        {
            txrPlayerBlue = contentManager.GetTexture("Content\\Images\\budBlue.png");
            txrPlayerYellow = contentManager.GetTexture("Content\\Images\\budYellow.png");
            txrPlayerRed = contentManager.GetTexture("Content\\Images\\budRed.png");
            txrBlack = contentManager.GetTexture("Content\\Images\\black.png");
            txrWhite = contentManager.GetTexture("Content\\Images\\white.png");
            txrFillBlue = contentManager.GetTexture("Content\\Images\\fillBlue.png");
            txrFillYellow = contentManager.GetTexture("Content\\Images\\fillYellow.png");
            txrFillRed = contentManager.GetTexture("Content\\Images\\fillRed.png");
            txrFilled = contentManager.GetTexture("Content\\Images\\filled.png");

            sprPlayer = new SprPlayer(txrPlayerBlue, //TODO pass size and color to new GameScreen
                new Vector2((Shri.Instance.Window.ClientBounds.Width / 2),
                (Shri.Instance.Window.ClientBounds.Height / 2 + 160)),
                new Circle(new Vector2((Shri.Instance.Window.ClientBounds.Width / 2),
                (Shri.Instance.Window.ClientBounds.Height / 2 + 160)), txrPlayerBlue.Width / 2),
                Color.White, new Vector2((txrPlayerBlue.Width) / 2, (txrPlayerBlue.Height) / 2),
                Color.Blue, true, 250, 1.0f, 90)
            {
                Scale = new Vector2(0.2f, 0.2f) //Always make sure to set custom scale after instance creation
            };
            sprPlayer.Circle.Radius = sprPlayer.Circle.Radius * sprPlayer.Scale.X;

            sprWallLeft = new SprWall(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f)
            };
            sprWallRight = new SprWall(txrBlack, new Vector2(Shri.Instance.Window.ClientBounds.Width - txrBlack.Width, 0), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(1f, 48f)
            };
            sprWallTop = new SprWall(txrBlack, Vector2.Zero, Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f)
            };
            sprWallBottom = new SprWall(txrBlack, new Vector2(0, Shri.Instance.Window.ClientBounds.Height - txrBlack.Height), Color.Black, Vector2.Zero)
            {
                Scale = new Vector2(80f, 1f)
            };
            
            sprExit = new SprExit(false, txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, 0), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1.5f)
            };
            sprEntrance = new SprEntrance(true, txrWhite, new Vector2(Shri.Instance.Window.ClientBounds.Width / 2, Shri.Instance.Window.ClientBounds.Height - txrWhite.Height), Color.White, new Vector2(txrWhite.Width / 2, 0))
            {
                Scale = new Vector2(20f, 1f)
            };

            _walls.Add(sprWallLeft);
            _walls.Add(sprWallRight);
            _walls.Add(sprWallTop);
            _walls.Add(sprWallBottom);

            txrMediumFont = contentManager.GetTexture("Content\\Fonts\\medium-font.png");
            sprMediumFont = new FramedSprite(18, 4, 0, txrMediumFont, Vector2.Zero, Color.White, false);
            Dictionary<int, int> mapping = contentManager.GetFontMapping("Content\\Fonts\\medium-font.fontmapping");
            fntMediumFont = new Font(sprMediumFont, mapping, 1, 2, Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            sprPlayer.Update(gameTime); //TODO reminder to always call sprite updates
            sprEntrance.Update(gameTime);
            sprExit.Update(gameTime);
            foreach (Sprite wall in _walls)
            {
                wall.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap);

            foreach (SprWall wall in _walls)
            {
                wall.Draw(spriteBatch);
            }

            if (sprExit.Open)
            {
                sprExit.Draw(spriteBatch);
            }

            if (sprEntrance.Open)
            {
                sprEntrance.Draw(spriteBatch);
            }
        }
    }
}
