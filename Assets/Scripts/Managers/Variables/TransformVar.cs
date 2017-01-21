/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;

namespace Logic
{  
    /// <summary>
    /// Global variable to store a transform
    /// </summary>
    public class TransformVar : GlobalVariable
    {
        /// <summary>
        /// Transform variable
        /// </summary>
        [SerializeField]
        private Transform m_Value = null;

        public override object Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = (Transform)value;
                OnValueChanged();
            }
        }
    }
}
