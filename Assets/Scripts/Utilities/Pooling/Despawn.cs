/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Action used to despawn a pool object, or deactivate a game object
    /// </summary>
    public class Despawn : Action
    {
        // Object to despawn
        [SerializeField]
        private GameObject m_Object = null;

        protected override Status UpdateNode()
        {
            PoolObject poolInstance = m_Object.GetComponent<PoolObject>();
            // validate 
            if (poolInstance != null)
            {
                Debug.Log("Return " + Time.time);
                poolInstance.Return();
            }
            else
            {
                m_Object.SetActive(false);
            }
            return Status.Success;
        }
    }
}
