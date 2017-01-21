/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Used to look at a global transform
    /// </summary>
    public class LookAtGlobalTransform : MonoBehaviour
    {
        [SerializeField]
        private Transform m_Object = null;
        [SerializeField]
        private string m_TransformID = null;
        private Transform m_TargetTransform = null;
        // Use this for initialization
        void Start()
        {
            m_TargetTransform = (Transform)GlobalVariables.Instance.GetValue(m_TransformID);
        }

        // Update is called once per frame
        void Update()
        {
            if(m_Object != null && m_TargetTransform != null)
            {
                m_Object.LookAt(m_TargetTransform);
            }
        }
    }
}
