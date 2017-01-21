using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Operation used for float type number operations
    /// </summary>
    public class FloatVarOperation : NumberVarOperations
    {
        /// <summary>
        /// Left side number
        /// </summary>
        [SerializeField]
        private FloatVar m_LeftNumber = null;
        /// <summary>
        /// Right side number
        /// </summary>
        [SerializeField]
        private FloatVar m_RightNumber = null;
        /// <summary>
        /// Result of operation
        /// </summary>
        [SerializeField]
        private FloatVar m_Result = null;

        public override Status UpdateAction()
        {
            if(m_LeftNumber == null || m_RightNumber == null || m_Result == null)
            {
                return Status.Error;
            }

            float result = 0;
            switch(m_NumberOperation)
            {
                case Operation.Division:
                    result = (float)m_LeftNumber.Value / (float)m_RightNumber.Value;
                    break;
                case Operation.Subtraction:
                    result = (float)m_LeftNumber.Value - (float)m_RightNumber.Value;
                    break;
                case Operation.Multiplication:
                    result = (float)m_LeftNumber.Value * (float)m_RightNumber.Value;
                    break;

                default:
                    result = (float)m_LeftNumber.Value + (float)m_RightNumber.Value;
                    break;
            }

            m_Result.Value = result;
            return Status.Success;
        }
    }
}
