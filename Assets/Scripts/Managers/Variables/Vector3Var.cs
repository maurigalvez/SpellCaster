/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Class used to pass Vector3 data across actions and other controllers
    /// </summary>
    public class Vector3Var : GlobalVariable
    {
        /// <summary>
        /// Value stored on this global variable
        /// </summary>
        [SerializeField]
        private Vector3 m_Value = Vector3.zero;


        public override object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = (Vector3)value;
                OnValueChanged();
            }
        }
    }
}
