/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;
namespace Logic
{
    /// <summary>
    /// Global Variable used to store a float value
    /// </summary>
    public class FloatVar : GlobalVariable
    {
        [SerializeField]
        private float m_Value = 0.0f;

        public override object Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = (float)value;
                OnValueChanged();
            }
        }
    }
}
