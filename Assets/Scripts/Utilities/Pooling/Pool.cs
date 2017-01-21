/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    public class Pool 
    {
        /// <summary>
        /// List of instances created
        /// </summary>
        [SerializeField]
        private Queue<GameObject> m_Instances = null;
        private PoolInfo m_Info = null;
        private int m_CurrentSpawned = 0;
        /// <summary>
        /// Constructor for this pool 
        /// </summary>
        /// <param name="instanceNumber"></param>
        public Pool(PoolInfo info)
        {
            // Initialize list
            m_Instances = new Queue<GameObject>();
            m_Info = info;
        }

        /// <summary>
        /// Returns next available instance, otherwise it returns null.
        /// </summary>
        /// <returns>Next available instance, otherwise it returns null.</returns>
        public GameObject NextInstance()
        {
            GameObject instance = null;
            if (m_CurrentSpawned < m_Info.m_InstanceNumber)
            {

                instance = GameObject.Instantiate(m_Info.m_ObjectPrefab);
                instance.SetActive(false);
                m_CurrentSpawned++;

            }
            // check if enough instances have been created
            else if (m_Instances.Count == 0)
            {
                return instance;
            }
            else
            {
                // return current instance
                instance = m_Instances.Dequeue();
            }
            if (instance != null)
            {               
                if (instance.GetComponent<PoolObject>() == null)
                {
                    PoolObject pObject = instance.AddComponent<PoolObject>();
                    pObject.m_Pool = this;
                    pObject.m_Lifetime = m_Info.m_LifeTime;
                }
            }            
            return instance;          
        }
        /// <summary>
        /// Returns instance to pool
        /// </summary>
        /// <param name="instance">Instance to return to pool</param>
        public void ReturnInstance(GameObject instance)
        {           
            instance.transform.rotation = Quaternion.identity;
            m_Instances.Enqueue(instance);
            instance.SetActive(false);
        }
    }
}
