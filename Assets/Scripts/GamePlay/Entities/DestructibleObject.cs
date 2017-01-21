using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Destructible object
    /// </summary>
    public class DestructibleObject : Entity
    {
        [SerializeField]
        private EntityInfo m_Info = null;
        protected override void Start()
        {
            base.Start();
            if (m_MaxHealth)
            {
                m_MaxHealth.Value = m_Info.m_MaxHealthPoints;
                m_Health.Value = (float)m_MaxHealth.Value;
            }
        }
    }
}
