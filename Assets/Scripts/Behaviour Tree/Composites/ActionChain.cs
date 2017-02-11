using UnityEngine;
using System.Collections;

namespace Logic
{
    public class ActionChain : Sequence
    {
        private int m_CurrentAction = 0; 

        public override Status UpdateNode()
        {
            Status status = Status.Success;
            // Check if there's actions
            if (m_Actions.Count == 0)
            {
                return Status.Error;
            }
            // Iterate through actions
            while (m_CurrentAction < m_Actions.Count)
            {
                if (m_CurrentAction == 0)
                {
                    // enter action
                    m_Actions[m_CurrentAction].Enter();
                }
                // update action
                status = m_Actions[m_CurrentAction].UpdateNode();
                // check if should keep running
                if(status == Status.Running)
                {
                    return status;
                }
                if (status != Status.Success)
                {
                    return status;
                }
                // exit action
                m_Actions[m_CurrentAction].Exit();
                m_CurrentAction++;
                if(m_CurrentAction < m_Actions.Count)
                {
                    m_Actions[m_CurrentAction].Enter();
                }
            }
            m_CurrentAction = 0;
            return Status.Success;
        }
    }
}
