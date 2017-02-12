/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Class used to define a Pool
    /// </summary>
    [CreateAssetMenu(fileName = "Pool", menuName = "Pooling/NewPool", order = 1)]
    public class PoolInfo : ScriptableObject
    {
        /// <summary>
        /// ID of this Pool
        /// </summary>
        [SerializeField]
        public string m_PoolID = "NewPool";

        [SerializeField]
        public GameObject m_ObjectPrefab = null;

        /// <summary>
        /// Number of instances to be created
        /// </summary>
        [SerializeField]
        public int m_InstanceNumber = 10;

        /// <summary>
        /// Life time of this particle. If -1 then lifetime will depend on other factors (e.g. collision).
        /// </summary>
        [SerializeField]
        public float m_LifeTime = -1;

        [SerializeField]
        public bool m_ParentToManager = false;
    }
}

