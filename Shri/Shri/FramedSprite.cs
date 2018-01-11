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
        public Size FrameSize
        {
            get
            {
                return _frameSize;
            }
        }
        
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
                int frameX = _currentFrame % _framesX;//TODO fix this by sending the character I want to use to this class
                int frameY = _currentFrame / _framesY; //TODO and this
                int locX = BorderSize + ((_borderSize + _frameSize.Width) * frameX);
                int locY = BorderSize + ((_borderSize + _frameSize.Height) * frameY);

                Console.WriteLine($"Frame: {_currentFrame}, X: {frameX}, Y: {frameY}, Width: {_frameSize.Width}, Height: {_frameSize.Height}");

                _sourceRectangle = new Rectangle(locX, locY, _frameSize.Width, _frameSize.Height);

                return _sourceRectangle;
            }
        }

        public FramedSprite(int framesX, int framesY, int borderSize, Texture2D texture, Vector2 position, Color tint, bool isPlayerControlled) : base(texture, position, tint, Vector2.Zero, isPlayerControlled)
        {
            _framesX = framesX;
            _framesY = framesY;
            _borderSize = borderSize;
            _currentFrame = 0;
            _frameSize = new Size
            {
                Width = (texture.Width - (FramesX * borderSize) - borderSize) / framesX,
                Height = (texture.Height - (FramesY * borderSize) - borderSize) / framesY
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Console.WriteLine(SourceRectangle); //Do not delete this line. It is a FramedSprite's rendering savior
            spriteBatch.Draw(_texture, position: _position, sourceRectangle: _sourceRectangle, color: _tint, scale: _scale, origin: _origin);
        }
    }
}
