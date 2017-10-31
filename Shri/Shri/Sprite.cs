using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        }

        protected Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                return _texture;
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

        protected int _height;
        public int Height
        {
            get
            {
                return _height;
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
        }
        
        public void SetTint(Color tint)
        {
            _tint = tint;
        }
        
        public void Update(GameTime gameTime)
        {
            if (IsPlayerControlled)
            {
                switch (Shri.Instance.GameScreenManager.CurrentGameScreen.Name)
                {
                    case "MainMenu":
                        if (Shri.Instance.InputManager.Pressed(Input.Start))
                        {
                            Shri.Instance.GameScreenManager.Push(new Level0());
                        }
                        break;

                    case "Level0": //TODO use this for more than just level0
                                   //case "Level1": <- That works for selecting multiple cases
                        if ((Keyboard.GetState().GetPressedKeys().Length > 0))
                        {
                            if (_locked == false)
                            {
                                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Left))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 135;
                                    this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                    this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Right))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 45;
                                    this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                    this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Left))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 225;
                                    this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                    this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Right))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 315;
                                    this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                    this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }

                                if (Shri.Instance.InputManager.Pressed(Input.Up))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 90;
                                    this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Down))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 270;
                                    this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Left))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 180;
                                    this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Right))
                                {
                                    _momentum = 1.0f;
                                    _mvmtDirection = 0;
                                    this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                }

                                if (Shri.Instance.InputManager.Pressed(Input.Grow))
                                {
                                    _scale += new Vector2(0.01f, 0.01f);
                                    if (_scale.X > 0.8f)
                                        _scale = new Vector2(0.8f, 0.8f);
#if DEBUG
                                    Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
#endif
                                }
                                if (Shri.Instance.InputManager.Pressed(Input.Shrink))
                                {
                                    _scale -= new Vector2(0.01f, 0.01f);
                                    if (_scale.X < 0.1f)
                                        _scale = new Vector2(0.1f, 0.1f);
#if DEBUG
                                    Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
#endif
                                }

                                if (_momentum > 0)
                                {
                                    _momentum -= 0.05f + (0.5f * (1 - _momentum));

                                    if (_momentum < 0)
                                        _momentum = 0;

                                    switch (_mvmtDirection)
                                    {
                                        case 0:
                                            this._position.X += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 45:
                                            this._position.X += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            this._position.Y -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 90:
                                            this._position.Y -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 135:
                                            this._position.X -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            this._position.Y -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 180:
                                            this._position.X -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 225:
                                            this._position.X -= (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            this._position.Y += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 270:
                                            this._position.Y += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                        case 315:
                                            this._position.X += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            this._position.Y += (_speed * _momentum) * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                                            break;
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                        break;
                }
                
                if (Shri.Instance.InputManager.Pressed(Input.Back))
                {
                    Shri.Instance.Exit();
                }
            }
            else
            {
                switch (Shri.Instance.GameScreenManager.CurrentGameScreen.Name)
                {
                    case "MainMenu":
                        break;

                    case "Level0": //TODO use this for more than just level0
                                   //case "Level1": <- That works for selecting multiple cases
                        break;
                }
            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, color:Color.White, scale:_scale, origin:_origin); //Color.White draws sprite normally (color parameter is color mask), scale isn't necessary so this line freaks out
        }
    }
}
