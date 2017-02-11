/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;

namespace Logic
{
    public class SetWeaponProjectile : Action
    {
        [SerializeField]
        private ProjectileWeaponInfo m_Weapon = null;

        [SerializeField]
        private ProjectileInfo m_NewProjectile = null;

        public override Status UpdateNode()
        {
            if(!m_Weapon || !m_NewProjectile)
            {
                return Status.Failure;
            }
            m_Weapon.Projectile = m_NewProjectile;
            return Status.Success;
        }
    }
}
