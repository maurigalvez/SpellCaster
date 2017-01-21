/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    public enum VariableType
    {
        Constant = 0,
        ObjectVar,
        GlobalVariable
    }

    /// <summary>
    /// Abstract class used to define global variable
    /// </summary>
    public abstract class GlobalVariable : MonoBehaviour
    {
        // Id of this global variable
        [SerializeField]
        public string VariableID = "";

        /// <summary>
        /// True if this variable is meant to be local
        /// </summary>
        [SerializeField]
        private bool m_Local = false;
        /// <summary>
        /// Delegate fired when value of this variable is changed
        /// </summary>
        public delegate void ValueChanged();
        public ValueChanged OnValueChanged = delegate { };

        public abstract object Value
        {
            get;
            set;
        }

        private void Awake()
        {
            if (m_Local == false)
            {
                GlobalVariables.Instance.RegisterVariable(this);
            }
        }
    }
}
