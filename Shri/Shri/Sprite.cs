using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    class Sprite
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

        protected bool _isPlayerControlled;
        public bool IsPlayerControlled
        {
            get
            {
                return _isPlayerControlled;
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color tint, bool isPlayerControlled = false)
        {
            _position = position;
            _texture = texture;
            _tint = tint;
            _isPlayerControlled = isPlayerControlled;
        }

        public void Update(GameTime gameTime)
        {
            if (IsPlayerControlled)
            {
                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Left))
                {
                    this._position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this._position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Right))
                {
                    this._position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this._position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Left))
                {
                    this._position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this._position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Right))
                {
                    this._position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this._position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }

                if (Shri.Instance.InputManager.Pressed(Input.Up))
                {
                    this._position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down))
                {
                    this._position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Left))
                {
                    this._position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Right))
                {
                    this._position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White); //Color.White draws sprite normally (color parameter is color mask)
        }

        internal void Location()
        {
            throw new NotImplementedException();
        }
    }
}
