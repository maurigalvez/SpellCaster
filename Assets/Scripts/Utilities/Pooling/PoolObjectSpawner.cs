using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{
    /// <summary>
    /// Abstract class used to initialze object spawners
    /// </summary>
    public class PoolObjectSpawner : Action
    {
        /// <summary>
        /// Object pool info to use for spawning
        /// </summary>
        [SerializeField]
        protected ObjectPoolInfo m_ObjectPoolInfo = null;

        /// <summary>
        /// Effect Spawn point
        /// </summary>
        [SerializeField]
        protected Transform m_ObjectSpawnPoint = null;

        /// <summary>
        /// Initialize object pool
        /// </summary>
        protected virtual void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            if(m_ObjectPoolInfo == null)
            {
                return;
            }
            m_ObjectPoolInfo.Initialize();
        }

        protected override Status UpdateNode()
        {
            if (m_ObjectSpawnPoint == null || m_ObjectPoolInfo == null)
            {
                return Status.Error;
            }
            PoolManager.NextInstance(m_ObjectPoolInfo,m_ObjectSpawnPoint.position);
            return Status.Success;
        }
    }
}
