using UnityEngine;
using System.Collections;
/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
namespace Logic
{
    /// <summary>
    /// Class used to store enemy information
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "Entity/Enemy/New Enemy", order = 1)]
    public class EnemyInfo : ScriptableObject
    {
        /// <summary>
        /// Total Health points
        /// </summary>
        [SerializeField]
        public float Health = 100.0f;
        /// <summary>
        /// Points gained after dead
        /// </summary>
        [SerializeField]
        public int Points = 10;

    }
}
