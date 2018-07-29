using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic.Utilities.Pooling
{
    /// <summary>
    /// Script used to handle pool manager controller events while in game
    /// </summary>
    public class PoolManagerController : Singleton<PoolManagerController>
    {
        /// <summary>
        /// Reset pools
        /// </summary>
        private void OnDestroy()
        {
            if (Instance == this)
            {
                PoolManager.ResetPools();
            }
        }
    }
}
