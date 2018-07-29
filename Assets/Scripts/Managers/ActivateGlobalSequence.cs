/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    public class ActivateGlobalSequence : Action
    {
        [SerializeField]
        private string m_SequenceID = "";

        protected override Status UpdateNode()
        {
            if(m_SequenceID.Length == 0)
            {
                return Status.Error;
            }
            if(!GlobalSequences.Instance.ActivateSequence(m_SequenceID))
            {
                return Status.Failure;
            }
            return Status.Success;
        }
    }
}
