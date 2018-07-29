using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Abstract of attack action
    /// </summary>
    public abstract class Attack : Action
    {
        /// <summary>
        /// Information of this attack
        /// </summary>
        [SerializeField]
        protected AttackInfo m_Info = null;

        /// <summary>
        /// Entity to use this attack
        /// </summary>
        [SerializeField]
        protected Entity m_Recipient = null;

        protected override Status UpdateNode()
        {
            return ExecuteAttack();
        }

        protected abstract Status ExecuteAttack();
    }
}
