using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Abstract class that defines a controller that will be used to detect input and trigger events
    /// </summary>
    public abstract class InputControl : MonoBehaviour
    {
        // Events fired on input
        [SerializeField]
        protected Sequence m_Events = null;
        // Delay for next input 
        [SerializeField]
        protected float m_Rate = 0.2f;

        protected float m_NextFire = 0.0f;
        protected void Update()
        {
           
            if( Time.time > m_NextFire && ValidateInput())
            {                
                m_NextFire = Time.time + m_Rate;
            }
        }

        public abstract bool ValidateInput();

        public virtual void FireEvents()
        {
            Debug.Log("Firing");
            if(m_Events != null)
            {
                m_Events.UpdateAction();
            }
        }
    }
}
