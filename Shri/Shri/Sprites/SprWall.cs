using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprWall : Wall
    {
        public SprWall(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {
                Level0 currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level0;

                if (this.Bounds.Intersects(currentGameScreen.sprPlayer.Bounds))
                {
                    Console.WriteLine(currentGameScreen.sprPlayer.Position.X - currentGameScreen.sprPlayer.Origin.X);
                    currentGameScreen.sprPlayer.Position = currentGameScreen.sprPlayer.PrevPosition;
                    Shri.Instance.SoundManager.PlaySound("Fill");
                }
            }
        }
    }
}
