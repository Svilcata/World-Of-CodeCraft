using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;


namespace World_Of_CodeCraft.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields
        protected Game1 GameRef;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            GameRef = (Game1)game;
        }
        #endregion
    }
}
