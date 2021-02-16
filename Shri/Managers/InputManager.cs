using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Managers
{
    /// <summary>
    /// Class used for managing input devices
    /// </summary>
    public class InputManager
    {
        public Dictionary<Keys, Input> KeyBindingsKeyboard;
        public Dictionary<Buttons, Input> KeyBindingsGamePad;
        private int playerInput;

        private bool _isUsingKBM;
        public bool IsUsingKBM
        {
            get
            {
                return _isUsingKBM;
            }
        }

        public KeyboardState KeyboardState
        {
            get
            {
                return Keyboard.GetState();
            }
        }

        public Keys[] PressedKeys
        {
            get
            {
                return KeyboardState.GetPressedKeys();
            }
        }

        public bool AreKeysPressed
        {
            get
            {
                return PressedKeys.Length > 0;
            }
        }

        protected MouseState _mouseState;
        public MouseState MouseState
        {
            get
            {
                return Mouse.GetState();
            }
        }

        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

        public InputManager()
        {
            KeyBindingsKeyboard = new Dictionary<Keys, Input>
                    {
                        { Keys.W, Input.Up },
                        { Keys.A, Input.Left },
                        { Keys.S, Input.Down },
                        { Keys.D, Input.Right },
                        { Keys.OemTilde, Input.Back },
                        { Keys.Escape, Input.Start },
                        { Keys.Enter, Input.Start },
                        { Keys.Up, Input.Grow },
                        { Keys.Down, Input.Shrink},
                        { Keys.D1, Input.Blue},
                        { Keys.D2, Input.Yellow},
                        { Keys.D3, Input.Red},
                        { Keys.Space, Input.Shoot }
                    };
            KeyBindingsGamePad = new Dictionary<Buttons, Input>
                    {
                        { Buttons.DPadUp, Input.Up },
                        { Buttons.DPadLeft, Input.Left },
                        { Buttons.DPadDown, Input.Down },
                        { Buttons.DPadRight, Input.Right },
                        { Buttons.Back, Input.Back },
                        { Buttons.Start, Input.Start },
                        { Buttons.RightTrigger, Input.Grow },
                        { Buttons.RightShoulder, Input.Grow },
                        { Buttons.LeftTrigger, Input.Shrink },
                        { Buttons.LeftShoulder, Input.Shrink },
                        { Buttons.X, Input.Blue },
                        { Buttons.Y, Input.Yellow },
                        { Buttons.B, Input.Red },
                        { Buttons.A, Input.Shoot }
                    };

            if (gamePadState.IsConnected == true) //TODO possibly add menu option to specifically select controller or keyboard
            {
                _isUsingKBM = false; //TODO add user menu option to configure _isUsingKBM value
            }
            else
            {
                _isUsingKBM = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            playerInput = 0;

            if (_isUsingKBM)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (KeyBindingsKeyboard.ContainsKey(key))
                    {
                        playerInput |= (int)KeyBindingsKeyboard[key];
                    }
                }
            }
            else
            {
                List<Buttons> pressedButtons = GetPressedButtons();

                foreach (Buttons button in KeyBindingsGamePad.Keys)
                {
                    if (gamePadState.Buttons.Start == ButtonState.Pressed)
                    {
                        //TODO fix gamepad button detection
                        playerInput |= (int)KeyBindingsGamePad[button];
                        //Console.WriteLine(button);
                    }
                }
            }
        }

        public List<Buttons> GetPressedButtons()
        {
            return Enum.GetValues(typeof(Buttons))
                       .Cast<Buttons>()
                       .Where(b => gamePadState.IsButtonDown(b))
                       .ToList();
        }

        public bool Pressed(params Input[] inputs)
        {
            int total = 0;

            foreach (var input in inputs)
            {
                total |= (int)input;
            }

            return playerInput == total;
        }
    }
}
