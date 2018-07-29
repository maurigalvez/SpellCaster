using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{
    /// <summary>
    /// Script used to define an object pool
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "Utilities/Object Pool", order = 1)]
    public class ObjectPoolInfo : ScriptableObject
    {
        /// <summary>
        /// Id of object pool
        /// </summary>       
        public System.Guid id = System.Guid.NewGuid();

        /// <summary>
        /// Object prefab for this pool.
        /// </summary>
        public GameObject objectPrefab = null;

        /// <summary>
        /// Number of instances to populate this pool with
        /// </summary>
        public int startInstances = 0;

        /// <summary>
        /// Lifetime of this pool object. If lifetime is -1, it will not despawned based on time
        /// </summary>
        public float lifetime = -1;

        /// <summary>
        /// Initialize this pool
        /// </summary>
        public void Initialize()
        {
            PoolManager.InitializePool(this);
        }
    }
}
