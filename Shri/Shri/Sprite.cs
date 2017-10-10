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
        public Vector2 Position;
        public Texture2D Texture;
        public bool IsPlayerControlled;

        public Sprite(Texture2D texture, Vector2 position, bool isPlayerControlled = false)
        {
            Texture = texture;
            Position = position;
            IsPlayerControlled = isPlayerControlled;
        }

        public void Update(GameTime gameTime)
        {
            if (IsPlayerControlled)
            {
                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Left))
                {
                    this.Position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this.Position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Up, Input.Right))
                {
                    this.Position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this.Position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Left))
                {
                    this.Position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this.Position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down, Input.Right))
                {
                    this.Position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                    this.Position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }

                if (Shri.Instance.InputManager.Pressed(Input.Up))
                {
                    this.Position.Y -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Down))
                {
                    this.Position.Y += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Left))
                {
                    this.Position.X -= 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
                if (Shri.Instance.InputManager.Pressed(Input.Right))
                {
                    this.Position.X += 30 * gameTime.ElapsedGameTime.Milliseconds / 1000f;
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White); //Color.White draws sprite normally
        }

        internal void Location()
        {
            throw new NotImplementedException();
        }
    }
}
