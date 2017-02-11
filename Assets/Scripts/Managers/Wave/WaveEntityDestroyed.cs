using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Action used to increase counter of wave entities destroyed
    /// </summary>
    public class WaveEntityDestroyed : Action
    {
        public override Status UpdateNode()
        {
            WaveManager.Instance.WaveEntityDestroyed();
            return Status.Success;
        }
    }
}
