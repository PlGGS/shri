using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Sprite(Texture2D texture, Vector2 position, Color tint, Vector2 origin, float scale = 1.0f, bool isPlayerControlled = false, int speed = 50)
        {
            _position = new Vector2(position.X * scale, position.Y * scale);
            _texture = texture;
            _tint = tint;
            _origin = origin;
            _scale = new Vector2(scale, scale);
            _isPlayerControlled = isPlayerControlled;
            _speed = speed;
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
                        if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Left))
                        {
                            this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                            this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Right))
                        {
                            this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                            this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Left))
                        {
                            this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                            this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Right))
                        {
                            this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                            this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }

                        if (Shri.Instance.InputManager.Pressed(Input.Up))
                        {
                            this._position.Y -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Down))
                        {
                            this._position.Y += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Left))
                        {
                            this._position.X -= _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Right))
                        {
                            this._position.X += _speed * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                        }

                        if (Shri.Instance.InputManager.Pressed(Input.Grow))
                        {
                            this.Scale += new Vector2(0.1f, 0.1f);
                        }
                        if (Shri.Instance.InputManager.Pressed(Input.Shrink))
                        {
                            this.Scale -= new Vector2(0.1f, 0.1f);
                        }
                        break;
                }

                if (Shri.Instance.InputManager.Pressed(Input.Back))
                {
                    Shri.Instance.Exit();
                }
            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, color:Color.White, scale:_scale, origin:_origin); //Color.White draws sprite normally (color parameter is color mask), scale isn't necessary so this line freaks out
        }

        internal void Location()
        {
            throw new NotImplementedException();
        }
    }
}
