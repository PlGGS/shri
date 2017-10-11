using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public abstract class GameScreen
    {
        protected bool initialized;
        public bool Initialized
        {
            get
            {
                return initialized;
            }
        }

        protected bool quit;
        public bool Quit
        {
            get
            {
                return quit;
            }
        }

        public virtual void Initialize()
        {
            initialized = true;
        }

        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
