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
    public class Entity : Sprite
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

        new public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                _circle.Center = value;
            }
        }

        protected Vector2 _prevPosition;
        public Vector2 PrevPosition
        {
            get
            {
                return _position;
            }
            set
            {
                _prevPosition = value;
            }
        }

        public Entity(Texture2D texture, Vector2 position, Circle circle, Color tint, Vector2 origin, Color color, bool isPlayerControlled = false, int speed = 50, float momentum = 0f, int mvmtDirection = 0, Vector2? scale = null)
            : base(texture, position, tint, origin, isPlayerControlled, speed, momentum, mvmtDirection, scale)
        {
            _circle = circle;
            _circle.Center = circle.Center;
            _circle.Radius = circle.Radius;
            _color = color;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shri.Instance.GameScreenManager.CurrentGameScreen is Level)
            {
                // Level currentGameScreen = Shri.Instance.GameScreenManager.CurrentGameScreen as Level;
                _prevPosition = _position;
                UpdateMomentum(gameTime);
            }
        }

        private void UpdateMomentum(GameTime gameTime)
        {
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
    }
}
