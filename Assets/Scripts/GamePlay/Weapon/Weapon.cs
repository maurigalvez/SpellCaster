using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Weapon behaviour
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {      
        /// <summary>
        /// Use this weapon
        /// </summary>
        public abstract void Use();
    }
}
