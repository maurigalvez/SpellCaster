using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Scriptable object used to create multiple variations of projectiles
    /// </summary>
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Weapon/Projectile/New Projectile", order = 1)]
    public class ProjectileInfo : ItemInfo
    {      
        [SerializeField]
        public float Speed = 0;
        [SerializeField]
        public float Damage = 0;
        [SerializeField]
        public string ModelPoolID = "";
        [SerializeField]
        public string EffectPoolID = ""; 
    }
}
