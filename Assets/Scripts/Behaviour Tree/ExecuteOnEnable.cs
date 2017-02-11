using UnityEngine;
using System.Collections;
namespace Logic
{
    public class ExecuteOnEnable : MonoBehaviour
    {
        [SerializeField]
        private BehaviourNode m_EventToExecute = null;

        private void OnEnable()
        {
            m_EventToExecute.Execute();
        }
    }
}
