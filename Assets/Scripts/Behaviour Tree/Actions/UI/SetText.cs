/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Action used to set text to a textfield
    /// </summary>
    public class SetText : Action
    {
        /// <summary>
        /// Text UI to change
        /// </summary>
        [SerializeField]
        private Text m_TextField = null;

        /// <summary>
        /// Set new text
        /// </summary> 
        [SerializeField]
        private string m_NewText = "";

        protected override Status UpdateNode()
        {
            if(m_TextField == null)
            {
                return Status.Error;
            }
            m_TextField.text = m_NewText;
            return Status.Success;
        }
    }
}
