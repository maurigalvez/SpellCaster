/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Struct used to define upgrade slots.
    /// </summary>
    [System.Serializable]
    public struct UpgradeSlot
    {
        [SerializeField]
        public ItemInfo info;
        [SerializeField]
        public float cost;
    }

    /// <summary>
    /// Scriptable object used to define item upgrades
    /// </summary>
    [CreateAssetMenu(fileName = "NewUpgradeInfo", menuName = "Item/New Upgrade Info", order = 1)]
    public class ItemUpgradeInfo : ScriptableObject
    {
        /// <summary>
        /// Id of this item upgrade info
        /// </summary>
        [SerializeField]
        public string ID = "newUpgradeInfo";

        /// <summary>
        /// Upgrade slots available
        /// </summary>
        [SerializeField]
        public UpgradeSlot[] Upgrades;

        /// <summary>
        /// Index of current upgrade
        /// </summary>
        [SerializeField]
        public int CurrentUpgradeIndex = 0;
    }
}
