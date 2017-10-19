using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class FramedSprite : Sprite
    {
        int _framesX;
        public int FramesX
        {
            get
            {
                return _framesX;
            }
        }

        int _framesY;
        public int FramesY
        {
            get
            {
                return _framesY;
            }
        }

        int _borderSize;
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
        }

        Size _frameSize;
        
        int _currentFrame;
        public int CurrentFrame
        {
            get
            {
                return _currentFrame;
            }
            set
            {
                _currentFrame = value;
            }
        }

        public FramedSprite(int framesX, int framesY, int borderSize, Texture2D texture, Vector2 position, Color tint, bool isPlayerControlled) : base(texture, position, tint, isPlayerControlled)
        {
            _framesX = framesX;
            _framesY = framesY;
            _borderSize = borderSize;
            _currentFrame = 0;
        }
    }
}
