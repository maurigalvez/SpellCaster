using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{
    /// <summary>
    /// Instance of pool object
    /// </summary>
    public class PoolObject : MonoBehaviour
    {
        public System.Action onDespawn = null;

        /// <summary>
        /// Reference to pool this object belongs to
        /// </summary>
        private ObjectPool m_ObjectPool = null;

        public void Initialize(ObjectPool pool)
        {
            m_ObjectPool = pool;
        }

        public void Despawn()
        {
            if(onDespawn != null)
            {
                onDespawn();
            }
            m_ObjectPool.Return(this.gameObject);
        }

        /// <summary>
        /// Initialize this pool object
        /// </summary>
        private void Start()
        {
            if(m_ObjectPool.Info.lifetime != -1)
            {
                StartCoroutine("LifetimeDelay");
            }
        }

        /// <summary>
        /// Coroutine in charge of running lifetime delay
        /// </summary>
        private IEnumerator LifetimeDelay()
        {
            yield return new WaitForSeconds(m_ObjectPool.Info.lifetime);
            Despawn();
        }
    }
}
