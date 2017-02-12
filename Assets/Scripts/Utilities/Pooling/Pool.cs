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
        public Pool(PoolInfo info, Transform parent)
        {
            // Initialize list
            m_Instances = new Stack<GameObject>();
            m_Info = info;              
        }

        /// <summary>
        /// Returns next available instance, otherwise it returns null.
        /// </summary>
        /// <returns>Next available instance, otherwise it returns null.</returns>
        public GameObject NextInstance()
        {           
            if(m_CurrentSpawned < m_Info.m_InstanceNumber)
            {
                GameObject instance = GameObject.Instantiate(m_Info.m_ObjectPrefab);
                instance.SetActive(false);
                if (m_Info.m_ParentToManager)
                {
                    instance.transform.SetParent(PoolManager.Instance.transform);
                }
                // Add pool object component and set properties
                PoolObject pObject = instance.AddComponent<PoolObject>();
                pObject.m_Pool = this;
                pObject.m_Lifetime = m_Info.m_LifeTime;
                m_CurrentSpawned++;
                return instance;
            }
            else if(m_Instances.Count > 0)
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
            if (m_Info.m_ParentToManager)
            {
                instance.transform.SetParent(PoolManager.Instance.transform);
            }
            m_Instances.Push(instance);            
        }
    }
}
