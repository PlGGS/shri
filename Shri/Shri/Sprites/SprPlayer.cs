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
        //int i = 0;

        public SprPlayer(Texture2D texture, Vector2 position, Color tint, Vector2 origin, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0)
            : base(texture,position,tint,origin,isPlayerControlled, speed,  momentum, mvmtDirection)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {
                Level0 currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level0;

                if (this.Bounds.Intersects(currentGameScreen.sprFill.Bounds))
                {
                    //Console.WriteLine(i++);
                }
                
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
            }
            /*else if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level1)
            {
                //use this pattern for later levels
            }*/

            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level0)
            {

            }/*else if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level1)
                {
                    //use this pattern for later levels
                }*/

            if (Shri.Instance.InputManager.Pressed(Input.Back))
            {
                Shri.Instance.Exit();
            }
        }
    }
}
