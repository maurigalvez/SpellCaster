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

    public class Sequence : EventNode
    {
        [SerializeField]
        protected List<EventNode> m_Actions = new List<EventNode>();

        protected override Status UpdateNode()
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
                m_Actions[currentAction].Execute(ref status);
                if (status != Status.Success)
                {
                    return status;
                }
                // exit action
                m_Actions[currentAction].Exit();
            }           
            return Status.Success;
        }      
    }
}
