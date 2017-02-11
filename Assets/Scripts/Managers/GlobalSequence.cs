/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Used to add Sequence to global sequences map
    /// </summary>
    [RequireComponent(typeof(Sequence))]
    public class GlobalSequence : MonoBehaviour
    {
        /// <summary>
        /// ID of sequence to be registered in map
        /// </summary>
        [SerializeField]
        private string m_SequenceID = "";

        /// <summary>
        /// Register sequence
        /// </summary>
        void OnEnable()
        {
            GlobalSequences.Instance.RegisterSequence(m_SequenceID, this.GetComponent<Sequence>());
        }

        /// <summary>
        /// Remove Sequence
        /// </summary>
        void OnDisable()
        {
            GlobalSequences.Instance.UnregisterSequence(m_SequenceID);
        }
        
    }
}
