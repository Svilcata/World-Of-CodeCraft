using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XRpgLibrary
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        
        #region KeyboardField
        private static KeyboardState keyboardState;
        private static KeyboardState lastKeyboardState;
        #endregion
        
        
        #region GamePadField
        static GamePadState[] gamePadStates; //There can be four game pads connected
        static GamePadState[] lastGamePadStates; //There can be four game pads connected
        #endregion

        #region KeyboardProperty
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }
        #endregion

        #region GamePadProperty
        public static GamePadState[] GamePadStates
        {
            get { return gamePadStates;}
        }

        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates;}
        }
        #endregion

        #region Constructor
        public InputHandler(Game game) : base(game)
        {
            keyboardState = Keyboard.GetState();
            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof (PlayerIndex)))
                gamePadStates[(int) index] = GamePad.GetState(index);
        }
        #endregion
        
        #region XnaMethods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            lastGamePadStates = (GamePadState[]) gamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof (PlayerIndex)))
                gamePadStates[(int) index] = GamePad.GetState(index);
            base.Update(gameTime);
        }
        #endregion

        #region GeneralMethod
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }
        #endregion
        //keyboard keymaping
        #region Keyboard
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }
        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }
        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        #endregion
        //gamepad keymaping
        #region GamePad
        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int) index].IsButtonUp(button) && lastGamePadStates[(int) index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(button) && lastGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int) index].IsButtonDown(button);
        }
        #endregion
    }
}

