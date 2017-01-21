using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Logic
{
    /// <summary>
    /// Image global variable
    /// </summary>
    public class ImageUIVar : GlobalVariable
    {
        [SerializeField]
        private Image m_Value;

        public override object Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = (Image)value;
            }
        }

    }
}
