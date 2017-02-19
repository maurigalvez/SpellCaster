using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    public class FloatCondition : NumberCondition
    {
        [SerializeField]
        private FloatVar m_LeftSide = null;

        [SerializeField]
        private float m_RightSide = 0;
        public override Status ValidateCondition()
        {
            if(m_LeftSide == null)
            {
                return Status.Error;
            }
            switch(m_NumberCondition)
            {              
                case NumberConditionMode.Greater:
                    if ((float)m_LeftSide.Value > m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
                case NumberConditionMode.GreaterAndEqual:
                    if ((float)m_LeftSide.Value >= m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
                case NumberConditionMode.Lower:
                    if ((float)m_LeftSide.Value < m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
                case NumberConditionMode.LowerAndEqual:
                    if ((float)m_LeftSide.Value <= m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
                case NumberConditionMode.NotEquals:
                    if ((float)m_LeftSide.Value != m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
                default:
                    if ((float)m_LeftSide.Value == m_RightSide)
                    {
                        return Status.Success;
                    }
                    break;
            }
            return Status.Failure;
        }
    }
}
