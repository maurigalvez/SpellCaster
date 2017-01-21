using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Used to update TextField using int value
    /// </summary>
    public class IntText : MonoBehaviour
    {
        /// <summary>
        /// Reference of text field
        /// </summary>
        [SerializeField]
        private Text m_TextField = null;

        /// <summary>
        /// Reference to int value
        /// </summary>
        [SerializeField]
        private IntVar m_IntValue = null;

        /// <summary>
        /// Format to be used when updating the text value
        /// </summary>
        [SerializeField]
        private string m_Format = "00";

        // Use this for initialization
        void Start()
        {
            // validate both needed values
            if(m_TextField && m_IntValue)
            {
                // hook update of text field when intVar changes
                m_IntValue.OnValueChanged += UpdateTextField;
            }
        }
        /// <summary>
        /// Updates text field with int value
        /// </summary>
        private void UpdateTextField()
        {
            int value = (int)m_IntValue.Value;
            m_TextField.text = value.ToString(m_Format);
        }
    }
}
