using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Weapon information class
    /// </summary>
    public abstract class WeaponInfo : ScriptableObject
    {
        /// <summary>
        /// Name of weapon
        /// </summary>
        [SerializeField]
        public string Name = "";
    }
}
