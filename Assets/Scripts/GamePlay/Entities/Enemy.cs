using UnityEngine;
using System.Collections;
/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
namespace Logic
{
    /// <summary>
    /// Class used to define an enemy entity
    /// </summary>
    public class Enemy : Entity
    {
        /// <summary>
        /// Instance of enemy info 
        /// </summary>
        [SerializeField]
        protected EnemyInfo m_Info = null;

        protected override void Start()
        {
            base.Start();
            m_MaxHealth.Value = m_Info.Health;
            m_Health.Value = (float)m_MaxHealth.Value;
            OnDead += AddPoints;
        }        
        
        /// <summary>
        /// Adds points to player
        /// </summary>
        protected void AddPoints()
        {
            StatsManager.Instance.AddPoints(m_Info.Points);
        }

    }
}
