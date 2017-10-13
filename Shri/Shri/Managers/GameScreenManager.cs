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
        private Stack<GameScreen> _gameScreens;
        public Stack<GameScreen> GameScreens
        {
            get
            {
                return _gameScreens;
            }
        }

        public GameScreenManager()
        {
            _gameScreens = new Stack<GameScreen>();
        }
        
        public void Push(GameScreen gameScreen)
        {
            _gameScreens.Push(gameScreen);
        }

        public void Update(GameTime gameTime)
        {
            bool gameScreenPopped = false;

            do
            {
                gameScreenPopped = false;

                if (_gameScreens.Count == 0)
                {
                    Shri.Instance.Exit();
                }

                GameScreen currentGameScreen = _gameScreens.Peek();

                if (currentGameScreen.Initialized == false)
                {
                    currentGameScreen.Initialize();
                    currentGameScreen.LoadContent(Shri.Instance.ContentManager);
                }

                currentGameScreen.Update(gameTime);

                if (currentGameScreen.Quit)
                {
                    GameScreens.Pop();
                    gameScreenPopped = true;
                }
            }
            while (gameScreenPopped);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_gameScreens.Peek().Initialized)
            {
                _gameScreens.Peek().Draw(spriteBatch);
            }
        }
    }
}
