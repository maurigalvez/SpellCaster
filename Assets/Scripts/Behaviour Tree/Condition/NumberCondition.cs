using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Condition abstract class used to define different number var based conditions.
    /// </summary>
    public abstract class NumberCondition : Condition
    {
        public enum NumberConditionMode
        {
            Equals = 0,
            NotEquals,
            Greater,
            GreaterAndEqual,
            Lower,
            LowerAndEqual
        }

        [SerializeField]
        protected NumberConditionMode m_NumberCondition = NumberConditionMode.Equals;
    }
}
