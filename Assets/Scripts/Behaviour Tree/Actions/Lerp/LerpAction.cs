/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Abstract used to define lerp actions
    /// </summary>
    public abstract class LerpAction : Action
    {
        [SerializeField]
        protected float m_Time = 2.0f;

        protected Status m_CurrentStatus = Status.Error;

        public override void Enter()
        {
            base.Enter();
            
            if (this.isActiveAndEnabled)
            {
                m_CurrentStatus = Status.Running;
                StartCoroutine("Interpolate");
            }
            else
            {
                m_CurrentStatus = Status.Failure;
            }
            
        }

        public override Status UpdateNode()
        {
            return m_CurrentStatus;
        }

        protected abstract IEnumerator Interpolate();
     

    }
}
