using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    public abstract class NumberVarOperations : Action
    {
        public enum Operation
        {
            Addition = 0,
            Subtraction,
            Multiplication,
            Division
        }
        /// <summary>
        /// Operation to be applied to numbers
        /// </summary>
        [SerializeField]
        protected Operation m_NumberOperation = Operation.Addition;

        /// <summary>
        /// Must be overriden. Otherwise it throws NotImplementedException
        /// </summary>
        /// <returns>Not Implemented Exception</returns>
        protected override Status UpdateNode()
        {
            throw new NotImplementedException();
        }
    }
}
