using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shri.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class Sprite
    {
        protected Vector2 _position;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        protected Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
            set
            {
                _texture = value;
            }
        }

        protected Color _tint;
        public Color Tint
        {
            get
            {
                return _tint;
            }
        }

        protected Vector2 _scale;
        public Vector2 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        protected Vector2 _origin;
        public Vector2 Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
            }
        }

        protected bool _isPlayerControlled;
        public bool IsPlayerControlled
        {
            get
            {
                return _isPlayerControlled;
            }
        }

        protected int _speed;
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        protected int _width;
        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int ScaledWidth
        {
            get
            {
                return (int)(_width * _scale.X);
            }
        }

        protected int _height;
        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int ScaledHeight
        {
            get
            {
                return (int)(_height * _scale.Y);
            }
        }

        /// <summary>
        /// Stores the sprite's current amount of momentum (Floating point values 0-1)
        /// </summary>
        protected float _momentum;
        public float Momentum
        {
            get
            {
                return _momentum;
            }
            set
            {
                _momentum = value;
            }
        }

        /// <summary>
        /// Stores the sprite's current direction of momentum (Int32 values 0-360)
        /// </summary>
        protected int _mvmtDirection;
        public int MvmtDirection
        {
            get
            {
                return _mvmtDirection;
            }
            set
            {
                _mvmtDirection = value;
            }
        }

        protected bool _locked;
        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }

        protected Rectangle _bounds;
        public Rectangle Bounds
        {
            get
            {
                //TODO check bounds on grow/shrink
                _bounds = new Rectangle((int)(_position.X - (_origin.X * _scale.X)), (int)(_position.Y - (_origin.Y * _scale.Y)), (int)(_width * _scale.X), (int)(_height * _scale.Y)); //fix bounds for object with different origins
                return _bounds;
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
        {
            _position = new Vector2(position.X, position.Y);
            _texture = texture;
            _tint = tint;
            _origin = origin;
            _isPlayerControlled = isPlayerControlled;
            _speed = speed;
            _width = (int)(texture.Width);
            _height = (int)(texture.Height);
            _momentum = momentum;
            _mvmtDirection = mvmtDirection;
            _scale = new Vector2(1.0f, 1.0f);
            _bounds = new Rectangle((int)_position.X - (int)Origin.X, (int)_position.Y - (int)Origin.Y, (int)(_width * _scale.X), (int)(_height * _scale.Y));
        }

        public void SetTint(Color tint)
        {
            _tint = tint;
        }
        
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White); //Color.White draws sprite normally (color parameter is color mask), scale isn't necessary so this line freaks out
        }
    }
}
