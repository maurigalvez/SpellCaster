using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Scriptable object used to define an attack
    /// </summary>
    [CreateAssetMenu(fileName = "New Attack Info", menuName = "Attack/New Attack", order = 1)]
    public class AttackInfo : ScriptableObject
    {
        [SerializeField]
        public float Damage = 100;
        [SerializeField]
        public string EffectPoolID = "";
    }
}
