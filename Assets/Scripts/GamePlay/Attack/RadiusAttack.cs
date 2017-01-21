using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Attack with effect in radius
    /// </summary>
    public class RadiusAttack : Attack
    {
        /// <summary>
        /// Radius of effect
        /// </summary>
        [SerializeField]
        private float m_Radius = 2.0f;
        /// <summary>
        /// Layermasks to be affected by attack
        /// </summary>
        [SerializeField]
        private LayerMask m_LayerMask;        
      
        protected override Status ExecuteAttack()
        {
            if(m_Recipient == null)
            {
                return Status.Error;
            }
            // obtain colliders hit by attack
            Collider[] colliders = Physics.OverlapSphere(m_Recipient.transform.position, m_Radius,m_LayerMask);
            EntityHitBox hitBox = null;
            for(int colliderIndex = 0; colliderIndex < colliders.Length; colliderIndex++)
            {
                hitBox = colliders[colliderIndex].transform.GetComponent<EntityHitBox>();
                if (hitBox != null)
                {
                    hitBox.ApplyDamage(m_Info.Damage);
                }
            }
            return Status.Success;
        }

        void OnDrawGizmos()
        {
            if(m_Recipient != null)
            {
                Gizmos.DrawWireSphere(m_Recipient.transform.position, m_Radius);
            }
        }
    }
}
