using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Entity info 
    /// </summary>
    [CreateAssetMenu(fileName = "NewEntityInfo", menuName = "Entity/New Entity Info", order = 1)]
    public  class EntityInfo : ScriptableObject
    {
        [SerializeField]
        public float m_MaxHealthPoints = 100;
    
    }
}
