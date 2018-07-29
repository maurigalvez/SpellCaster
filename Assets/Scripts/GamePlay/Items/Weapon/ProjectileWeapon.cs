/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Instance of weapon
    /// </summary>
    public class ProjectileWeapon : Weapon
    {
        enum OriginMode
        {
            Default = 0,
            GlobalVariable
        }
        /// <summary>
        /// Information of this weapon
        /// </summary>
        [SerializeField]
        private ProjectileWeaponInfo m_WeaponInfo = null;
        /// <summary>
        /// Transform of projectile spawn point
        /// </summary>
        [SerializeField]
        private Transform m_FireLocation = null;

        [SerializeField]
        private string m_TransformID = null;
        /// <summary>
        /// Variable with direction of projectile
        /// </summary>
        [SerializeField]
        private Vector3Var m_ProjectileDirection = null;

        /// <summary>
        /// Shoot weapon
        /// </summary>
        public override void Use()
        {
            if(m_FireLocation == null && m_TransformID.Length > 0)
            {
                m_FireLocation = GlobalVariables.Instance.GetValue(m_TransformID) as Transform;
            }
            // Spawn projectile
            if (m_FireLocation)
            {
                // Spawn projectile
                GameObject instance = PoolManager.Instance.NextInstance(m_WeaponInfo.Projectile.ModelPoolID);
                if (instance == null)
                {
                    Debug.LogError("[ERROR] ProjectileWeapon : Instance from pool manager is null");
                    return;
                }
                // assign position
                instance.transform.position = m_FireLocation.position;
                Projectile projectile = instance.GetComponent<Projectile>();
                // add a projectile component if onehasn't been added
                if (projectile == null)
                {
                    projectile = instance.AddComponent<Projectile>();
                }
                // fire projectile
                if (m_ProjectileDirection && (Vector3)m_ProjectileDirection.Value != Vector3.zero)
                {
                    projectile.Fire(m_WeaponInfo.Projectile, (Vector3)m_ProjectileDirection.Value);
                }
                else
                {
                    projectile.Fire(m_WeaponInfo.Projectile, m_FireLocation.forward);
                }
                instance = null;
                projectile = null;      
            }   
        }
    }
}
