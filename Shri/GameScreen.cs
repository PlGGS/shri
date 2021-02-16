using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shri.Managers;

namespace Shri
{
    public abstract class GameScreen //TODO add bool to gamescreen to initially set mouse cursor in the center of the screen
    {
        protected bool _initialized;
        public bool Initialized
        {
            get
            {
                return _initialized;
            }
        }

        protected bool _quit;
        public bool Quit
        {
            get
            {
                return _quit;
            }
            set
            {
                _quit = value;
            }
        }

        public virtual void Initialize()
        {
            _initialized = true;
        }

        public virtual void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
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
