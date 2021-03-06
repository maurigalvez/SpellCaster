﻿/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using Logic.Utilities.Pooling;
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

        protected override Status UpdateNode()
        {
            // validate pools and targets
            if(m_Pool == null || m_SpawnTargets.Length == 0)
            {
                return Status.Error;
            }           
           
            Spawn(PoolManager.NextInstance(m_Pool));
            return Status.Success;
        }

        public override void Spawn(GameObject instance)
        {
            //Debug.Log("Spawn " + Time.time);
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
