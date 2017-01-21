using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Information for projectile weapon
    /// </summary>
    [CreateAssetMenu(fileName = "NewProjectileWeapon", menuName = "Weapon/New Projectile Weapon", order = 1)]
    public class ProjectileWeaponInfo : WeaponInfo
    {
        /// <summary>
        /// Weapon Fire Rate
        /// </summary>
        [SerializeField]
        public float FireRate = 2.0f;
        /// <summary>
        /// Ammo of weapon. -1 when its infinite.
        /// </summary>
        [SerializeField]
        public int Ammo = 20;
        /// <summary>
        /// Projectile to use for this weapon
        /// </summary>
        [SerializeField]
        public ProjectileInfo m_Projectile = null;
       
    }
}
