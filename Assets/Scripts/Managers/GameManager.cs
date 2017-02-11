/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Used to manage main states of the game
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Delegate fired when game state is changed
        /// </summary>
        public delegate void GameStateChange();
        public GameStateChange OnStateChanged;
        /// <summary>
        /// Delegate fired when game is over
        /// </summary>
        public delegate void GameOverEvent();
        public GameOverEvent OnGameOver;
       
        /// <summary>
        /// Enum used to define different states of the game
        /// </summary>
        public enum GameState
        {
            Inactive = 0,
            InGame,
            Paused,
            GameOver
        }

        /// <summary>
        /// Current state of the game
        /// </summary>
        private GameState m_CurrentState = GameState.Inactive;

        /// <summary>
        /// State of game
        /// </summary>
        public GameState State
        {
            get
            {
                return m_CurrentState;
            }
            set
            {
                m_CurrentState = value;
                OnStateChanged();
            }
        }

        /// <summary>
        /// Initialize Game Manager and hook events
        /// </summary>
        private void Start()
        {
            OnStateChanged += CheckState;
        }

        /// <summary>
        /// Checks states of game
        /// </summary>
        private void CheckState()
        {
            if(m_CurrentState == GameState.GameOver)
            {
                OnGameOver();
            }
        }
 
    }
}
