/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class that defines a game entity (e.g Player, Enemy, NPC).
/// </summary>
namespace Logic
{
    public abstract class Entity : MonoBehaviour
    {
        /// <summary>
        /// Float variable to store max health of this entity
        /// </summary>
        [SerializeField]
        protected FloatVar m_MaxHealth = null;
          
        /// <summary>
        /// Float variable to store health of this entity
        /// </summary>
        [SerializeField]
        protected FloatVar m_Health = null;

        /// <summary>
        /// Sequence to be fired when entity receives damage
        /// </summary>
        [SerializeField]
        protected Sequence m_OnHitSequence = null;

        /// <summary>
        /// Sequence to be fired on entities' death
        /// </summary>
        [SerializeField]
        protected Sequence m_OnDeadSequence = null;

        /// <summary>
        /// Delegate used to hook events fired when entity is dead
        /// </summary>
        public delegate void DeadEvent();
        public DeadEvent OnDead = delegate { };

        /// <summary>
        /// Delegate used to hook events fired when entity takes damage
        /// </summary>
        /// <param name="damage">Amount of damage taken on hit</param>
        public delegate void HitEvent(float damage);
        public HitEvent OnHit = delegate { };


        protected virtual void Start()
        {
            StartCoroutine("Initialize");           
        }

        /// <summary>
        /// Initialize this entity
        /// </summary>
        protected IEnumerator Initialize()
        {           
            // Add hooks
            OnHit += ApplyDamage;          
            if (m_OnDeadSequence)
            {
                OnDead += m_OnDeadSequence.Execute;
            }
            // add recipient to projectile targets
            EntityHitBox[] projTargets = this.transform.GetComponentsInChildren<EntityHitBox>();
            // validate projTargets          
            for (int projIndex = 0; projIndex < projTargets.Length; projIndex++)
            {
                projTargets[projIndex].Recipient = this;
            }            
            yield return null;
        }

        /// <summary>
        /// Reduces damage from health and fires dead event
        /// </summary>
        /// <param name="damage">Damage received</param>
        protected virtual void ApplyDamage(float damage)
        {           
            m_Health.Value = (float)m_Health.Value - damage;
            if (m_OnHitSequence)
            {
                m_OnHitSequence.Execute();
            }
            if ((float)m_Health.Value <= 0)
            {
                OnDead();
            }
        }
    }
}
