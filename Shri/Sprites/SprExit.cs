using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprExit : Door
    {
        public SprExit(bool open, Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(open, texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level)
            {
                Level currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level;
                
                Console.WriteLine($"{currentGameScreen.Player.ScaledWidth}, {this.ScaledWidth}");
                if (this.Bounds.Intersects(currentGameScreen.Player.Bounds) &&
                    currentGameScreen.Player.Bounds.X > this.Bounds.X &&
                    currentGameScreen.Player.Bounds.X + currentGameScreen.Player.ScaledWidth < this.Bounds.X + this.ScaledWidth &&
                    this.Open)
                {
                    currentGameScreen.sprWallTop.Thru = true;
                }
                else
                {
                    currentGameScreen.sprWallTop.Thru = false;
                }

                if (currentGameScreen.Player.Position.Y <= ((currentGameScreen.Player.Height * currentGameScreen.Player.Scale.Y) * -1) / 2)
                {
                    if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
                    {
                        Shri.Instance.GameScreenManager.Push(new Level1(currentGameScreen.Player));
                    }
                    else if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level1)
                    {
                        Shri.Instance.GameScreenManager.Push(new Level2(currentGameScreen.Player));
                    }
                }
            }
        }
    }
}
