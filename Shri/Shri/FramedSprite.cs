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

        Rectangle _sourceRectangle;
        public Rectangle SourceRectangle
        {
            get
            {
                int frameX = _currentFrame / _framesX;
                int frameY = _currentFrame % _framesY;
                int textureX = BorderSize + ((_borderSize + _frameSize.Width) * frameX);
                int textureY = BorderSize + ((_borderSize + _frameSize.Height) * frameY);

                _sourceRectangle = new Rectangle(textureX, textureY, _frameSize.Width, _frameSize.Height);

                return _sourceRectangle;
            }
        }

        public FramedSprite(int framesX, int framesY, int borderSize, Texture2D texture, Vector2 position, Color tint, bool isPlayerControlled) : base(texture, position, tint, isPlayerControlled)
        {
            _framesX = framesX;
            _framesY = framesY;
            _borderSize = borderSize;
            _currentFrame = 0;
            _frameSize = new Size
            {
                Width = (texture.Width - (FramesX * borderSize) - borderSize) / framesX,
                Height = (texture.Height - (FramesY * borderSize) - borderSize) / frames
            };
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _sourceRectangle, _tint);
        }
    }
}
