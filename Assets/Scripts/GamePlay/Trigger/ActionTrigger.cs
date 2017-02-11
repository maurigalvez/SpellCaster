/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Trigger used to fire actions on trigger enter
    /// </summary>
    public class ActionTrigger : Trigger
    {
        [SerializeField]
        protected string[] m_Targets;

        protected void OnTriggerEnter(Collider other)
        {
            for(int targetIndex = 0; targetIndex < m_Targets.Length; targetIndex++)
            {
                if(other.transform.GetComponent(m_Targets[targetIndex]))
                {
                    FireActions();
                }
            }
        } 
    }
}
