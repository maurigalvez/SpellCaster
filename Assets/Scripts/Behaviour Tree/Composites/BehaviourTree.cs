/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    /// <summary>
    /// Class in charge of iterating through nodes and updating them.
    /// </summary>
    public class BehaviourTree : MonoBehaviour
    {
        [SerializeField]
        private List<EventNode> m_Children = new List<EventNode>();

        void OnEnable()
        {
            if (m_Children.Count == 0)
            {
                Debug.LogWarning("BehaviourTree : No actions were added");
            }
            StartCoroutine("UpdateTree");
        }

        private IEnumerator UpdateTree()
        {            
            Status status = Status.Success;
            int currentChild = 0;
            // enter first child
            m_Children[currentChild].Enter();
            while (status != Status.Error)
            {               
                // obtain status of current child
                m_Children[currentChild].Execute(ref status);
                // parse status
                switch(status)
                {
                    case Status.Error:
                        Debug.LogError("There was an error when updating child " + m_Children[currentChild].name);                          
                        break;

                    case Status.Continue:
                        yield return new WaitForEndOfFrame();
                        break;

                    default:
                        // exit current child
                        m_Children[currentChild].Exit();
                        // go to next child
                        currentChild++;
                        if(currentChild == m_Children.Count)
                        {
                            currentChild = 0;
                        }
                        // enter current child
                        m_Children[currentChild].Enter();
                        break;
                }
                yield return new WaitForFixedUpdate();
            }
            // Deactivate this game object
            this.gameObject.SetActive(false);
        }

        void OnDisable()
        {
            StopCoroutine("UpdateTree");
        }
    }
}
