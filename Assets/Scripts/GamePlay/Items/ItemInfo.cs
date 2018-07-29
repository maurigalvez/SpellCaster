/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// scriptable object class to define items' info.
    /// </summary>
    public abstract class ItemInfo : ScriptableObject
    {
        /// <summary>
        /// Name of Item
        /// </summary>
        [SerializeField]
        public string Name = "";
    }
}
