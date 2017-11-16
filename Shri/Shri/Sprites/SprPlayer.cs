using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Sprites
{
    public class SprPlayer : Sprite
    {
        protected Color _color;
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        protected Circle _circle;
        public Circle Circle
        {
            get
            {
                return _circle;
            }
            set
            {
                _circle = value;
            }
        }

        protected Vector2 _prevPosition;
        public Vector2 PrevPosition
        {
            get
            {
                return _prevPosition;
            }
        }

        public SprPlayer(Texture2D texture, Vector2 position, Circle circle, Color tint, Vector2 origin, Color color, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection)
        {
            _circle = circle;
            _circle.Center = circle.Center;
            _circle.Radius = circle.Radius;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {
                Level0 currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level0;

                Console.WriteLine(_momentum);

                if ((Keyboard.GetState().GetPressedKeys().Length > 0))
                {
                    if (_locked == false)
                    {
                        _prevPosition = _position;

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
                            float tmpScale = _scale.X;

                            _scale += new Vector2(0.01f, 0.01f);
                            if (_scale.X > 0.8f)
                                _scale = new Vector2(0.8f, 0.8f);

                            _circle.Radius = _texture.Width / 2 * _scale.X;
#if DEBUG
                            Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
#endif
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Shrink))
                        {
                            float tmpScale = _scale.X;

                            _scale -= new Vector2(0.01f, 0.01f);
                            if (_scale.X < 0.1f)
                                _scale = new Vector2(0.1f, 0.1f);

                            _circle.Radius = _texture.Width / 2 * _scale.X;
#if DEBUG
                            Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
#endif
                        }
                        
                        if (Shri.Instance.InputManager.Pressed(Input.Blue))
                        {
                            _texture = currentGameScreen.txrPlayerBlue;
                            _color = Color.Blue;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Yellow))
                        {
                            _texture = currentGameScreen.txrPlayerYellow;
                            _color = Color.Yellow;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Red))
                        {
                            _texture = currentGameScreen.txrPlayerRed;
                            _color = Color.Red;
                        }
                    }
                }
            }
            /*else if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level1)
            {
                //use this pattern for later levels
            }*/

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

            if (Shri.Instance.InputManager.Pressed(Input.Back))
            {
                Shri.Instance.Exit(); //TODO find out why exit crashes the game rather than seemlessly closing it
            }

            _circle.Center = _position;
        }
    }
}
