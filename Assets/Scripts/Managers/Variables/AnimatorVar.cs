/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Global variable used to store an animator instance
    /// </summary>
    public class AnimatorVar : GlobalVariable
    {
        [SerializeField]
        private Animator m_Value = null;

        public override object Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = (Animator)value;
                OnValueChanged();
            }
        }
    }
}
