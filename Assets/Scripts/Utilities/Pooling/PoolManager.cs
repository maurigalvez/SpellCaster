/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    /// <summary>
    /// Manager in charge of creating pools for projectiles/VFX/Entities
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        /// <summary>
        /// List of pools that can be used to spawn objects in scene
        /// </summary>
        [SerializeField]
        private List<PoolInfo> m_Pools = new List<PoolInfo>();
        /// <summary>
        /// Dictionary to be used to save all instances of pools
        /// </summary>
        [SerializeField]
        private Dictionary<string, Pool> m_PoolMap = new Dictionary<string, Pool>();

        /// <summary>
        /// Initalize PoolManager
        /// </summary>
        void Awake()
        {
            StartCoroutine("Initialize");
        }

        /// <summary>
        /// Creates pools to use for spawning
        /// </summary>
        private IEnumerator Initialize()
        {
            // Iterate through list and add to map
            for (int pool = 0; pool < m_Pools.Count; pool++)
            {
                m_PoolMap.Add(m_Pools[pool].m_PoolID, new Pool(m_Pools[pool]));
            }
            // check if pools if empty
            if(m_PoolMap.Count ==0)
            {
                Debug.LogWarning("PoolManager : Pool Map is empty!");
            }
            // Clear list
            m_Pools.Clear();
            yield return null;
        }

        /// <summary>
        /// Returns next available instance in pool with given ID. If ID is invalid, or not enough instances are available, it returns null.
        /// </summary>
        /// <param name="m_PoolID">ID of pool to grab next instance from.</param>
        /// <returns>Next available instance in pool with given ID. If ID is invalid, or not enough instances are available, it returns null</returns>
        public GameObject NextInstance(string m_PoolID)
        {
            // check if pools if empty
            if (m_PoolMap.Count == 0)
            {
                Debug.LogWarning("PoolManager : Pool Map is empty. Returning null");
                return null;
            }
            // Obtain gameobject instance
            Pool pool = null;
            m_PoolMap.TryGetValue(m_PoolID, out pool);
            if(pool == null)
            {
                Debug.LogError("PoolManager: Pool with ID " + m_PoolID + " was not found. Returning null.");
                return null;
            }
            return pool.NextInstance();
        }
    }
}
