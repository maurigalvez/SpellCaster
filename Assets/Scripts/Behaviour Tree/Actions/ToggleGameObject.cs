/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Enables/Disables game objects
    /// </summary>
    public class ToggleGameObject : Action
    {        
        [SerializeField]
        private GameObject[] m_Objects = null;

        [SerializeField]
        private bool m_IsEnabled = false;

        protected override Status UpdateNode()
        {
            if(m_Objects.Length == 0)
            {
                return Status.Failure;
            }

            for(int objectIndex = 0; objectIndex < m_Objects.Length; objectIndex++)
            {
                m_Objects[objectIndex].SetActive(m_IsEnabled);
            }

            return Status.Success;
        }     

    }
}
