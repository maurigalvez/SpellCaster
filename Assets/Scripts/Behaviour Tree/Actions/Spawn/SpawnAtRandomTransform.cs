/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Action to be used to spawn one or a series of game objects selected at random at random targets.
    /// </summary>
    public class SpawnAtRandomTransform : SpawnObject
    {
        /// <summary>
        /// Pools of objects to be spawned
        /// </summary>
        //[SerializeField]
        //private string[] m_Pools;

        /// <summary>
        /// Transforms to be used to spawn object
        /// </summary>
        [SerializeField]
        private Transform[] m_SpawnTargets;

        [SerializeField]
        private float m_Height = 0.0f;

        /// <summary>
        /// True if transform rotation should be applied to the spawned object
        /// </summary>
        [SerializeField]
        private bool m_ApplyTransformRotation = false;

        public override Status UpdateAction()
        {
            // validate pools and targets
            if(m_PoolID.Length ==0 || m_SpawnTargets.Length == 0)
            {
                return Status.Error;
            }

            GameObject instance = PoolManager.Instance.NextInstance(m_PoolID);//m_Pools[Random.Range(0, m_Pools.Length)]);
            if(instance == null)
            {
                return Status.Failure;
            }
            Spawn(instance);
            return Status.Success;
        }

        public override void Spawn(GameObject instance)
        {
            // get position
            Transform targetTransform = m_SpawnTargets[Random.Range(0, m_SpawnTargets.Length)];
            Vector3 targetPosition = targetTransform.position;
            // set height
            if (m_Height > 0)
            {
                targetPosition.y = m_Height;
            }
            instance.transform.position = targetPosition;            
            // check if rotation should be applied
            if(m_ApplyTransformRotation)
            {
                instance.transform.rotation = targetTransform.rotation;
            }
            // activate instance
            instance.SetActive(true);
        }
    }
}
