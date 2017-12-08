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

                if (this.Bounds.Intersects(currentGameScreen.sprPlayer.Bounds))
                {
                    if (this.Open)
                    {
                        /*
                        switch (Shri.Instance.GameScreenManager.CurrentGameScreen.GetType()) //TODO enumerate type of Levels
                        {
                            case Level0:
                                Shri.Instance.GameScreenManager.Push(new Level1());
                                break;
                        }
                        */

                        Shri.Instance.GameScreenManager.Push(new Level1());
                    }
                }
            }
        }
    }
}
