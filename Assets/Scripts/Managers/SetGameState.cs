/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Action used to set state of the game
    /// </summary>
    public class SetGameState : Action
    {
        /// <summary>
        /// New game state
        /// </summary>
        [SerializeField]
        private GameManager.GameState m_NewGameState;

        protected override Status UpdateNode()
        {
            GameManager.Instance.State = m_NewGameState;
            return Status.Success;
        }
    }
}
