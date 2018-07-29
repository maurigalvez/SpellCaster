/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Action used to set position of an object on world space
    /// </summary>
    public class SetPosition : Action
    {
        /// <summary>
        /// Object to move
        /// </summary>
        [SerializeField]
        private Transform m_Recipient = null;
        /// <summary>
        /// Point in World space to move object to
        /// </summary>
        [SerializeField]
        private Vector3Var m_WorldPosition = null;

        protected override Status UpdateNode()
        {
            Debug.Log("Updating position");
            // validate
            if(m_Recipient == null || m_WorldPosition == null)
            {
                return Status.Error;
            }
            // set position of recipient
            m_Recipient.position = (Vector3)m_WorldPosition.Value;
            return Status.Success;
        }

    }
}
