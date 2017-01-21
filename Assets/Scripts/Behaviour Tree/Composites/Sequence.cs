/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    /// <summary>
    /// List of actions that will be updated one after another.
    /// Moves to next action once it returns success. If action returns running it will updated the next frame.
    /// When it returns failure then it stops.
    /// </summary>

    public class Sequence : BehaviourNode
    {
        [SerializeField]
        private List<BehaviourNode> m_Actions = new List<BehaviourNode>();

        public override Status UpdateAction()
        {
            Status status = Status.Success;
            // Check if there's actions
            if(m_Actions.Count == 0)
            {
                return Status.Error;
            }           
            // Iterate through actions
            for(int currentAction =0; currentAction < m_Actions.Count; currentAction++)
            {
                // enter action
                m_Actions[currentAction].Enter();
                // update action
                status = m_Actions[currentAction].UpdateAction();
                if (status != Status.Success)
                {
                    return status;
                }
                // exit action
                m_Actions[currentAction].Exit();
            }           
            return Status.Success;
        }

        /// <summary>
        /// Allows this sequence to be executed outside of a behaviour tree
        /// </summary>
        public virtual void Execute()
        {
            UpdateAction();
        }
    }
}
