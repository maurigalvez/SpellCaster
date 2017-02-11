using UnityEngine;
using System.Collections;
namespace Logic
{
    public class NotDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }    
}
