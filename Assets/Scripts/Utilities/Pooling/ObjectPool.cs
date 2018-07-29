using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{
    /// <summary>
    /// Class used to define an object pool
    /// </summary>
    public class ObjectPool
    {
        /// <summary>
        /// Info of this pool
        /// </summary>
        private ObjectPoolInfo m_PoolInfo = null;
        /// <summary>
        /// Get info of this object pool
        /// </summary>
        public ObjectPoolInfo Info
        {
            get
            {
                return m_PoolInfo;
            }
        }

        /// <summary>
        /// List of object instances created on this pool
        /// </summary>
        private Stack<GameObject> m_ObjectInstances = null;

        /// <summary>
        /// True when is initialized
        /// </summary>
        private bool m_IsInitialized = false;

        /// <summary>
        /// Object Pool class constructor
        /// </summary>
        /// <param name="poolInfo">PoolInfo used to initialize this Object Pool</param>
        public ObjectPool(ObjectPoolInfo poolInfo)
        {
            Initialize(poolInfo);
        }

        /// <summary>
        /// Initializes object pool
        /// </summary>
        private void Initialize(ObjectPoolInfo poolInfo)
        {
            if(m_IsInitialized)
            {
                return;
            }
            m_PoolInfo = poolInfo;
            m_IsInitialized = true;
            m_ObjectInstances = new Stack<GameObject>();
        
            // spawn gameObjects
            for(int oIndex = 0; oIndex < m_PoolInfo.startInstances; oIndex++)
            {
                CreateInstance();
            }
        }

        /// <summary>
        /// Creates a new object instance
        /// </summary>
        private void CreateInstance()
        {           
            GameObject newInstance = GameObject.Instantiate(m_PoolInfo.objectPrefab);
            PoolObject pObject = newInstance.AddComponent<PoolObject>();
            pObject.Initialize(this);
            newInstance.SetActive(false);
            m_ObjectInstances.Push(newInstance);
        }
        
        /// <summary>
        /// Get next available instance
        /// </summary>
        public GameObject NextInstance()
        {
            // validate object instances
            if(m_ObjectInstances == null)
            {
                return null;
            }
            if(m_ObjectInstances.Count == 0)
            {
                CreateInstance();
            }
            return m_ObjectInstances.Pop();
        }

        /// <summary>
        /// Returns object instance
        /// </summary>
        public void Return(GameObject objectInstance)
        {
            objectInstance.SetActive(false);
            m_ObjectInstances.Push(objectInstance);
        }
    }
}
