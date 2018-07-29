/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;
namespace Logic
{
    /// <summary>
    /// BehaviourNode that will be used to define condition behaviour nodes
    /// </summary>
    public abstract class Condition : EventNode
    {
        protected override Status UpdateNode()
        {
            return ValidateCondition();
        }

        public abstract Status ValidateCondition();
    }
}
