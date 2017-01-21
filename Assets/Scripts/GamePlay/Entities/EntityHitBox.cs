using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Defines a target that can be hurt by a projectile
    /// </summary>
    public class EntityHitBox : MonoBehaviour
    {
        /// <summary>
        /// Reference to recipient of this target
        /// </summary>
        protected Entity m_Recipient = null;

        /// <summary>
        /// Recipient of this projectiletarget instance
        /// </summary>
        public Entity Recipient
        {
            set
            {
                m_Recipient = value;
            }
        }

        public void ApplyDamage(float damage)
        {
            m_Recipient.OnHit(damage);
        }
    }
}
