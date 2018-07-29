using UnityEngine;
using System.Collections;

/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
namespace Logic
{
    /// <summary>
    /// Action used to set parameter for animator
    /// </summary>
    public class SetAnimatorParameter : Action
    {
        [SerializeField]
        public Animator m_Animator = null;

        [SerializeField]
        public AnimatorVar m_AnimatorVar = null;

        [SerializeField]
        public string m_AnimatorID = null;

        [SerializeField]
        public string m_ParameterID = "";

        public enum ParameterType
        {
            Trigger,
            Bool,
            Float
        }
        [SerializeField]
        public ParameterType m_ParameterType;
        [SerializeField]
        public float m_FloatValue = 0;
        [SerializeField]
        public bool m_BoolValue = false;

        protected override Status UpdateNode()
        {
            // validate
            if(m_Animator == null)
            {
                return Status.Error;
            }
            // set parameter
            switch(m_ParameterType)
            {
                case ParameterType.Float:
                    m_Animator.SetFloat(m_ParameterID, m_FloatValue);
                    break;

                case ParameterType.Bool:
                    m_Animator.SetBool(m_ParameterID, m_BoolValue);
                    break;

                default:
                    m_Animator.SetTrigger(m_ParameterID);
                    break;
            }
            return Status.Success;
        }

    }
}
