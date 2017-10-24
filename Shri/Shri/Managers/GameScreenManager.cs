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
        Stack<GameScreen> _gameScreens;
        public Stack<GameScreen> GameScreens
        {
            get
            {
                return _gameScreens;
            }
        }

        GameScreen _currentGameScreen;
        public GameScreen CurrentGameScreen
        {
            get
            {
                return _currentGameScreen;
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

                _currentGameScreen = GameScreens.Peek();

                if (_currentGameScreen.Initialized == false)
                {
                    _currentGameScreen.Initialize();
                    _currentGameScreen.LoadContent(Shri.Instance.ContentManager);
                }

                _currentGameScreen.Update(gameTime);

                if (_currentGameScreen.Quit)
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
