using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class GameScreenManager
    {
        private Stack<GameScreen> gameScreens;
        public Stack<GameScreen> GameScreens
        {
            get
            {
                return gameScreens;
            }
        }

        public GameScreenManager()
        {
            gameScreens = new Stack<GameScreen>();
        }
        
        public void Push(GameScreen gameScreen)
        {
            gameScreens.Push(gameScreen);
        }

        public void Update(GameTime gameTime)
        {
            bool gameScreenPopped = false;

            while (gameScreenPopped)
            {
                gameScreenPopped = false;

                if (gameScreens.Count == 0)
                {
                    Shri.Instance.Exit();
                }

                GameScreen currentGameScreen = gameScreens.Peek();

                if (currentGameScreen.Initialized == false)
                {
                    currentGameScreen.Initialize();
                    currentGameScreen.LoadContent(Shri.Instance.GraphicsDevice);
                }

                currentGameScreen.Update(gameTime);

                if (currentGameScreen.Quit)
                {
                    GameScreens.Pop();
                    gameScreenPopped = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (gameScreens.Peek().Initialized)
            {
                gameScreens.Peek().Draw(spriteBatch);
            }
        }
    }
}
