using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Shri.Sprites;
using System;

namespace Shri.Managers
{
    /// <summary>
    /// Class used for managing player's control of the current player sprite
    /// </summary>
    public class ControlManager
    {
        protected Entity _player;
        public Entity Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }

        protected Sprite _intersecting;
        public Sprite Intersecting
        {
            get
            {
                return _intersecting;
            }
        }

        protected bool _isIntersecting;
        public bool IsIntersecting
        {
            get
            {
                return _intersecting != null;
            }
        }

        protected bool _isLocked;
        /// <summary>
        /// Whether or not to restrict player input (Excluding Input.Start for pausing)
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
            }
        }

        public ControlManager(Entity player, bool isLocked)
        {
            _player = player;
            _isLocked = isLocked;
        }

        public void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level)
            {
                Level currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level;

                if (Shri.Instance.InputManager.IsUsingKBM)
                {
                    if (_isLocked == false)
                    {
                        _player.Position = new Vector2(Shri.Instance.InputManager.MouseState.X, Shri.Instance.InputManager.MouseState.Y);

                        if (Shri.Instance.InputManager.AreKeysPressed)
                        {
                            if (Shri.Instance.InputManager.Pressed(Input.Blue))
                            {
                                _player.Texture = currentGameScreen.txrPlayerBlue;
                                // _color = Color.Blue;
                            }
                            if (Shri.Instance.InputManager.Pressed(Input.Yellow))
                            {
                                _player.Texture = currentGameScreen.txrPlayerYellow;
                                // _color = Color.Yellow;
                            }
                            if (Shri.Instance.InputManager.Pressed(Input.Red))
                            {
                                _player.Texture = currentGameScreen.txrPlayerRed;
                                // _color = Color.Red;
                            }

                            if (Shri.Instance.InputManager.Pressed(Input.Grow))
                            {
                                bool intersecting = false;

                                foreach (SprWall wall in currentGameScreen.Walls)
                                {
                                    if (_player.Bounds.Intersects(wall.Bounds))
                                    {
                                        intersecting = true; //TODO make this instead calculate whether or not you will be intersecting after Grow()ing
                                        Shrink();
                                    }
                                }

                                if (!intersecting)
                                {
                                    Grow();
                                }
                            }
                            if (Shri.Instance.InputManager.Pressed(Input.Shrink))
                            {
                                Shrink();
                            }
                        }
                    }

                    if (Shri.Instance.InputManager.Pressed(Input.Back))
                    {
                        Shri.Instance.Exit(); //TODO find out why exit crashes the game rather than seemlessly closing it
                    }
                }
                else
                {
                    //TODO add gamepad support
                }
            }
        }

        public void Grow()
        {
            float tmpScale = _player.Scale.X;

            _player.Scale += new Vector2(0.01f, 0.01f);
            if (_player.Scale.X > 0.8f)
                _player.Scale = new Vector2(0.8f, 0.8f);

            _player.Circle.Radius = _player.Texture.Width / 2 * _player.Scale.X;
#if DEBUG
            Console.WriteLine(new Vector2(((_player.Width * _player.Scale.X) / 2), ((_player.Height * _player.Scale.Y) / 2)));
#endif
        }

        public void Shrink()
        {
            float tmpScale = _player.Scale.X;

            _player.Scale -= new Vector2(0.01f, 0.01f);
            if (_player.Scale.X < 0.1f)
                _player.Scale = new Vector2(0.1f, 0.1f);

            _player.Circle.Radius = _player.Texture.Width / 2 * _player.Scale.X;
#if DEBUG
            Console.WriteLine(new Vector2(((_player.Width * _player.Scale.X) / 2), ((_player.Height * _player.Scale.Y) / 2)));
#endif
        }
    }

    /*
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
    */

    //                 if ((Keyboard.GetState().GetPressedKeys().Length > 0))
    //                 {
    //                     if (_locked == false)
    //                     {
    //                         _prevPosition = _position;

    //                         if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Left))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 135;
    //                             this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                             this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Right))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 45;
    //                             this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                             this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Left))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 225;
    //                             this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                             this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Right))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 315;
    //                             this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                             this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }

    //                         if (Shri.Instance.InputManager.Pressed(Input.Up))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 90;
    //                             this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Down))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 270;
    //                             this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Left))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 180;
    //                             this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Right))
    //                         {
    //                             _momentum = 1.0f;
    //                             _mvmtDirection = 0;
    //                             this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
    //                         }

    //                         if (Shri.Instance.InputManager.Pressed(Input.Grow))
    //                         {
    //                             bool intersecting = false;

    //                             foreach (SprWall wall in currentGameScreen.Walls)
    //                             {
    //                                 if (this.Bounds.Intersects(wall.Bounds))
    //                                 {
    //                                     intersecting = true;
    //                                     Shrink();
    //                                 }
    //                             }

    //                             if (!intersecting)
    //                             {
    //                                 Grow();
    //                             }
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Shrink))
    //                         {
    //                             Shrink();
    //                         }

    //                         void Grow()
    //                         {
    //                             float tmpScale = _scale.X;

    //                             _scale += new Vector2(0.01f, 0.01f);
    //                             if (_scale.X > 0.8f)
    //                                 _scale = new Vector2(0.8f, 0.8f);

    //                             _circle.Radius = _texture.Width / 2 * _scale.X;
    // #if DEBUG
    //                             Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
    // #endif
    //                         }

    //                         void Shrink()
    //                         {
    //                             float tmpScale = _scale.X;

    //                             _scale -= new Vector2(0.01f, 0.01f);
    //                             if (_scale.X < 0.1f)
    //                                 _scale = new Vector2(0.1f, 0.1f);

    //                             _circle.Radius = _texture.Width / 2 * _scale.X;
    // #if DEBUG
    //                             Console.WriteLine(new Vector2(((_width * _scale.X) / 2), ((_height * _scale.Y) / 2)));
    // #endif
    //                         }

    //                         if (Shri.Instance.InputManager.Pressed(Input.Blue))
    //                         {
    //                             _texture = currentGameScreen.txrPlayerBlue;
    //                             _color = Color.Blue;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Yellow))
    //                         {
    //                             _texture = currentGameScreen.txrPlayerYellow;
    //                             _color = Color.Yellow;
    //                         }
    //                         if (Shri.Instance.InputManager.Pressed(Input.Red))
    //                         {
    //                             _texture = currentGameScreen.txrPlayerRed;
    //                             _color = Color.Red;
    //                         }
    //                     }
    //                 }
}
/*else if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level1)
{
    //use this pattern for later levels
}*/