using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Used to create a trigger that will fire actions 
    /// </summary>
    public abstract class Trigger : MonoBehaviour
    {
        [SerializeField]
        protected Action[] m_Actions = null;

        protected virtual void FireActions()
        {
            for(int currentAction = 0; currentAction < m_Actions.Length; currentAction++)
            {
                m_Actions[currentAction].Enter();
                m_Actions[currentAction].UpdateAction();
                m_Actions[currentAction].Exit();
            }
        }
       
    }
}
