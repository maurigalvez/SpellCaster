/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    /// <summary>
    /// Interpolate between original and final scale in set time
    /// </summary>
    public class LerpScale : LerpAction
    {
        [SerializeField]
        private Transform m_Object = null;

        [SerializeField]
        private Vector3 m_InitialScale = Vector3.zero;

        [SerializeField]
        private Vector3 m_FinalScale = new Vector3(1, 1, 1);


        protected override IEnumerator Interpolate()
        {
            if(!m_Object)
            {
                m_CurrentStatus = Status.Error;
            }
            else
            {                
                float elapsed = 0;
                while(elapsed < m_Time)
                {                 
                    elapsed += Time.fixedDeltaTime;
                    m_Object.localScale = Vector3.Lerp(m_InitialScale, m_FinalScale,elapsed/m_Time);
                    yield return null;
                }
                m_CurrentStatus = Status.Success;
            }            
        }

    }
}
