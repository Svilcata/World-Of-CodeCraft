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
    public class GameStateManager : GameComponent
    {
        #region Event
        public event EventHandler OnStateChange;
        #endregion

        #region FieldsAndProperties
        Stack<GameState> gameStates = new Stack<GameState>();
        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;
        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }
        #endregion

        #region Constructor
        public GameStateManager(Game game) : base(game)
        {
            drawOrder = startDrawOrder;
        }
        #endregion

        #region XNAMethod
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        #endregion

        #region Methods
        public void PopState() //PopState is the method to call if you have a screen on top of the stack that you want to remove and go back to the previous screen
        {
            if (gameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;
                if (OnStateChange != null)
                    OnStateChange(this, null);
            }
        }
        private void RemoveState() //The RemoveState method first gets which state is on top of the stack
        {
            GameState State = gameStates.Peek();
            OnStateChange -= State.StateChange;
            Game.Components.Remove(State);
            gameStates.Pop();
        }
        public void PushState(GameState newState) //PushState is the method to call if you want to move to another state and keep the previous state
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;
            AddState(newState);
            if (OnStateChange != null)
                OnStateChange(this, null);
        }
        private void AddState(GameState newState)
        {
            gameStates.Push(newState);
            Game.Components.Add(newState);
            OnStateChange += newState.StateChange;
        }
        public void ChangeState(GameState newState) //ChangeState, is called when you wish to remove all other states from the stack
        {
            while (gameStates.Count > 0)
                RemoveState();
            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;
            AddState(newState);
            if (OnStateChange != null)
                OnStateChange(this, null);
        }
        #endregion
    }
}

