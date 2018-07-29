using UnityEngine;
using System.Collections;
using Logic.Utilities.Pooling;
namespace Logic
{
    /// <summary>
    /// Class that defines a projectile object 
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        // Information of projectile
        protected ProjectileInfo m_ProjectileInfo = null;
        // Instance of projectile's transform
        protected Transform m_Transform = null;    
 
        /// <summary>
        /// Initialize This projectile
        /// </summary>
        /// <param name="info"></param>
        /// <param name="direction"></param>
        public virtual void Fire(ProjectileInfo info, Vector3 direction)
        {
            m_ProjectileInfo = info;
            m_Transform = this.transform;            
            m_Transform.LookAt(direction);
            this.gameObject.SetActive(true);        
        
        }
        /// <summary>
        /// Coroutine used to translate projectile
        /// </summary>
        protected void Update()
        {          
            m_Transform.position += m_Transform.forward * m_ProjectileInfo.Speed * Time.deltaTime;
            
        }
        /// <summary>
        /// Collision Enter Callback
        /// </summary>
        protected virtual void OnCollisionEnter(Collision other)
        {
            // Spawn projectile effect
            if (m_ProjectileInfo.effectPool != null)
            {
                GameObject effect = PoolManager.NextInstance(m_ProjectileInfo.effectPool);
                // position effect on collision point
                if(effect != null)
                {
                    effect.transform.position = other.contacts[0].point;
                    effect.SetActive(true);
                }
            }

            // Apply damage if collided with target
            EntityHitBox projTarget = other.transform.GetComponent<EntityHitBox>();
            if (projTarget != null)
            {
                projTarget.ApplyDamage(m_ProjectileInfo.Damage);
            }

            // check if this object is a pool object
            PoolObject poolObject = this.GetComponent<PoolObject>();
            if (poolObject != null)
            {
                poolObject.Despawn();
            }
            else
            {
                // Disable this gameobject
                this.gameObject.SetActive(false);
            }
        }
    }
}
