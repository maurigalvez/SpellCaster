/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Global Variable used to store an int value
    /// </summary>
    public class IntVar : GlobalVariable
    {
        [SerializeField]
        private int m_Value = 0;

        public override object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = (int)value;
                OnValueChanged();
            }
        }
    }
}
