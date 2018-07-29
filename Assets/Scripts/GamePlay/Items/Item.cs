using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Abstract class used to define equipabble/usable items
    /// </summary>
    public abstract class Item : MonoBehaviour
    {
        /// <summary>
        /// Use this weapon
        /// </summary>
        public abstract void Use();
    }
}
