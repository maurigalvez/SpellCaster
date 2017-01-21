/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Script used to define a poolable object
    /// </summary>
    public class PoolObject : MonoBehaviour
    {
        /// <summary>
        /// Reference of pool that this object belongs to
        /// </summary>
        [SerializeField]
        public Pool m_Pool = null;

        public float m_Lifetime = -1f;

        public void OnEnable()
        {
            if(m_Lifetime > 0)
            {
                StartCoroutine("Delay");
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(m_Lifetime);
            Return();
        }

        public void Return()
        {
            m_Pool.ReturnInstance(this.gameObject);
        }

        private void OnDisable()
        {
            Return();
        }
    }
}
