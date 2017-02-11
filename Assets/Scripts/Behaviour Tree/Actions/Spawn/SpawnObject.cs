/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    /// <summary>
    /// Action used to spawn an object. The object is spawned at origin.
    /// </summary>
    public class SpawnObject : Action
    {
        // Pool id of objects to spawn
        [SerializeField]
        protected string m_PoolID = "";

        public override Status UpdateNode()
        {
            // Validate id
            if(m_PoolID.Length == 0 || m_PoolID == "")
            {
                return Status.Error;
            }

            GameObject instance = PoolManager.Instance.NextInstance(m_PoolID);

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
