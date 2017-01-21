using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Logic
{
    /// <summary>
    /// behaviour used to set image fill amount
    /// </summary>
    public class SetImageFillAmount : MonoBehaviour
    {
        [SerializeField]
        private string m_ImageGlobalID = null;
        [SerializeField]
        private Image m_Image = null;
        [SerializeField]
        private FloatVar m_FillAmount = null;
        
        void Start()
        {
            if(m_ImageGlobalID.Length != 0)
            {
                m_Image = (Image)GlobalVariables.Instance.GetValue(m_ImageGlobalID);
            }
            if(m_Image != null && m_FillAmount != null)
            {
                m_FillAmount.OnValueChanged += UpdateFillAmount;
            }
        }        

        /// <summary>
        /// Updates fill ammount using stored value
        /// </summary>
        private void UpdateFillAmount()
        {
            m_Image.fillAmount = (float)m_FillAmount.Value;
        }

    }
}
