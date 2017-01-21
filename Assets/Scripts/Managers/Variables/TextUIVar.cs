/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Global variable to store a text UI
    /// </summary>
    public class TextUIVar : GlobalVariable
    {
        [SerializeField]
        private Text m_Value = null;

        public override object Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = (Text)value;
                OnValueChanged();
            }
        }
    }
}
