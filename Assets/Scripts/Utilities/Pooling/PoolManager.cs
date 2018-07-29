using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{    
    /// <summary>
    /// Manager used to manage pooling
    /// </summary>
    public class PoolManager
    {
        static private Dictionary<System.Guid, ObjectPool> m_ObjectPools = null;
     
        /// <summary>
        /// Initializes pool info
        /// </summary>
        public static void InitializePool(ObjectPoolInfo poolInfo)
        {
            if(m_ObjectPools == null)
            {
                m_ObjectPools = new Dictionary<System.Guid, ObjectPool>();
            }
            // check if there's a pool manager instance
            if (PoolManagerController.Instance == null)
            {
                GameObject poolMC = new GameObject("PoolManagerController");
                poolMC.AddComponent<PoolManagerController>();
            }            
            // check if pool has been already initialized
            if(m_ObjectPools.ContainsKey(poolInfo.id))
            {
                return;
            }
            else
            {
                ObjectPool newPool = new ObjectPool(poolInfo);
                m_ObjectPools.Add(poolInfo.id, newPool);
            }
        }

        /// <summary>
        /// Next instance on this pool info
        /// </summary>
        public static GameObject NextInstance(ObjectPoolInfo poolInfo)
        {
            GameObject nextInstance = m_ObjectPools[poolInfo.id].NextInstance();
            nextInstance.SetActive(true);
            return nextInstance;
        }

        /// <summary>
        /// Next instance on this pool info
        /// </summary>
        public static GameObject NextInstance(ObjectPoolInfo poolInfo, Vector3 position)
        {
            GameObject nextInstance = m_ObjectPools[poolInfo.id].NextInstance();
            nextInstance.transform.position = position;
            nextInstance.SetActive(true);
            return nextInstance;
        }

        /// <summary>
        /// Next instance on this pool info
        /// </summary>
        public static GameObject NextInstance(ObjectPoolInfo poolInfo, Vector3 position, Quaternion rotation)
        {
            GameObject nextInstance = NextInstance(poolInfo, position);
            nextInstance.transform.rotation = rotation;
            return nextInstance;
        }
        
        /// <summary>
        /// Reset object pools
        /// </summary>
        public static void ResetPools()
        {
            m_ObjectPools = null;
        }
    }
}
