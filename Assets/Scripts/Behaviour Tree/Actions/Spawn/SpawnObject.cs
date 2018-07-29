/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;
using Logic.Utilities.Pooling;
namespace Logic
{
    /// <summary>
    /// Action used to spawn an object. The object is spawned at origin.
    /// </summary>
    public class SpawnObject : Action
    {
        // Pool id of objects to spawn
        [SerializeField] protected ObjectPoolInfo m_Pool;

        protected void Start()
        {
            if(m_Pool != null)
            {
                m_Pool.Initialize();
            }
        }

        protected override Status UpdateNode()
        {
            // Validate id
            if(m_Pool == null)
            {
                return Status.Error;
            }

            GameObject instance = PoolManager.NextInstance(m_Pool);

            if(instance == null)
            {
                return Status.Failure;
            }

            Spawn(instance);

            return Status.Success;
        }


        public virtual void Spawn(GameObject instance)
        {
            instance.SetActive(true);
            instance.transform.position = Vector3.zero;
            instance.transform.rotation = Quaternion.identity;
        }
    }
}
