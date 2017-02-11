/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    public class UseWeapon : Action
    {
        /// <summary>
        /// Reference to weapon to use
        /// </summary>
        [SerializeField]
        private Weapon m_Weapon = null;

        public override Status UpdateNode()
        {
            // validate
            if (!m_Weapon)
            {
                return Status.Error;
            }
            // Use Weapon
            m_Weapon.Use();
            return Status.Success;
        }
    }
}
