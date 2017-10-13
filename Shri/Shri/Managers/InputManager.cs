﻿using Microsoft.Xna.Framework;
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
            if (gamePadState.IsConnected)
            {
                isUsingKeyboard = false; //TODO update this so that InputManager's isUsingKeyboard value is configurable
            }
            else
            {
                isUsingKeyboard = true;
            }
            
            KeyBindingsKeyboard = new Dictionary<Keys, Input>
            {
                { Keys.W, Input.Up },
                { Keys.A, Input.Left },
                { Keys.S, Input.Down },
                { Keys.D, Input.Right },
                { Keys.Escape, Input.Back }
            };
            KeyBindingsGamePad = new Dictionary<Buttons, Input>
            {
                { Buttons.DPadUp, Input.Up },
                { Buttons.DPadLeft, Input.Left },
                { Buttons.DPadDown, Input.Down },
                { Buttons.DPadRight, Input.Right },
                { Buttons.Back, Input.Back }
            };
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