using UnityEngine;
using System.Collections;
using Logic.Utilities.Pooling;
namespace Logic
{
    /// <summary>
    /// Scriptable object used to create multiple variations of projectiles
    /// </summary>
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Weapon/Projectile/New Projectile", order = 1)]
    public class ProjectileInfo : ItemInfo
    {              
        public float Speed = 0;        
        public float Damage = 0;
        public ObjectPoolInfo modelPool = null;        
        public ObjectPoolInfo effectPool = null; 

        public void Initialize()
        {
            modelPool.Initialize();
            effectPool.Initialize();
        }
    }
}
