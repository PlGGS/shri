using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprEntrance : Door
    {
        int closeSoundCounter = 0;

        public SprEntrance(bool open, Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(open, texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (closeSoundCounter >= 10)
            {
                closeSoundCounter = -1;

                if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
                {
                    Level0 currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level0;

                    if (!this.Bounds.Intersects(currentGameScreen.sprPlayer.Bounds))
                    {
                        this.Open = false;
                        Shri.Instance.SoundManager.PlaySound("Close");
                    }
                }
            }
            else if (closeSoundCounter != -1)
            {
                closeSoundCounter++;
            }
        }
    }
}
