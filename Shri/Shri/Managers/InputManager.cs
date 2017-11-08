using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class InputManager
    {
        public Dictionary<Keys, Input> KeyBindingsKeyboard;
        public Dictionary<Buttons, Input> KeyBindingsGamePad;

        private bool isUsingKeyboard;

        private int playerInput;
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

            if (gamePadState.IsConnected) //TODO possibly add menu option to specifically select controller or keyboard
            {
                isUsingKeyboard = false; //TODO update this so that InputManager's isUsingKeyboard value is configurable
            }
            else
            {
                isUsingKeyboard = true;
            }
        }

        public void Update()
        {
            playerInput = 0;

            if (isUsingKeyboard)
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
                foreach (KeyValuePair<Buttons, Input> keyValuePair in KeyBindingsGamePad)
                {
                    //TODO fix gamepad detection
                    if (gamePadState.IsButtonDown(keyValuePair.Key))
                    {
                        playerInput |= (int)keyValuePair.Value;
                    }
                }
            }
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
