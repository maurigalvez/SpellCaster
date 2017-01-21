/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    [System.Serializable]
    public class Pool 
    {
        /// <summary>
        /// List of instances created
        /// </summary>
        [SerializeField]
        private Stack<GameObject> m_Instances = null;
        [SerializeField]
        private PoolInfo m_Info = null;
        [SerializeField]
        private int m_CurrentSpawned = 0;
        /// <summary>
        /// Constructor for this pool 
        /// </summary>
        /// <param name="instanceNumber"></param>
        public Pool(PoolInfo info)
        {
            // Initialize list
            m_Instances = new Stack<GameObject>();
            m_Info = info;
            GameObject instance = null; 
            for(int currentInstance = 0; currentInstance < m_Info.m_InstanceNumber; currentInstance++)
            {
                // create new game object instance
                instance = GameObject.Instantiate(m_Info.m_ObjectPrefab);
                instance.SetActive(false);
                // Add pool object component and set properties
                PoolObject pObject = instance.AddComponent<PoolObject>();
                pObject.m_Pool = this;
                pObject.m_Lifetime = m_Info.m_LifeTime;
                // add to queue
                m_Instances.Push(instance);
            }
        }

        /// <summary>
        /// Returns next available instance, otherwise it returns null.
        /// </summary>
        /// <returns>Next available instance, otherwise it returns null.</returns>
        public GameObject NextInstance()
        {           
            if(m_Instances.Count > 0)
            {
                return m_Instances.Pop();
            }       
            return null;          
        }
        /// <summary>
        /// Returns instance to pool
        /// </summary>
        /// <param name="instance">Instance to return to pool</param>
        public void ReturnInstance(GameObject instance)
        {           
            instance.transform.rotation = Quaternion.identity;
            instance.SetActive(false);
            m_Instances.Push(instance);            
        }
    }
}
