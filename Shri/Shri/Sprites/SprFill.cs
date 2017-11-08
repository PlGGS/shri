using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprFill : Sprite
    {
        private int holdTimer;

        protected bool _filled;
        public bool Filled
        {
            get
            {
                return _filled;
            }
            set
            {
                _filled = value;
            }
        }

        protected bool _holdPlayer;
        public bool HoldPlayer
        {
            get
            {
                return _holdPlayer;
            }
            set
            {
                _holdPlayer = value;
            }
        }

        /// <summary>
        /// Sets time before becoming unfilled again. 0 if infinite
        /// </summary>
        protected int _timer;
        public int Timer
        {
            get
            {
                return _timer;
            }
            set
            {
                _timer = value;
            }
        }

        public SprFill(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0, int timer = 0)
            : base(texture, position, tint, origin, isPlayerControlled, speed,  momentum, mvmtDirection)
        {
            _timer = timer;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {
                Level0 currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level0;
                
                Console.WriteLine(_filled);

                if (_holdPlayer) //TODO set _holdPlayer
                {                //TODO set color parameter for fill objects
                    if (holdTimer == 0)
                    {
                        //play satisfying sound
                    }

                    if (holdTimer < 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f)
                    {
                        holdTimer += 1;
                        currentGameScreen.sprPlayer.Locked = true;
                    }
                    else
                    {
                        currentGameScreen.sprPlayer.Locked = false;
                        _holdPlayer = false;
                        holdTimer = 0;
                        _filled = true;
                    }
                }
            }
        }
    }
}
