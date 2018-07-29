/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Logic
{
    /// <summary>
    /// Manager used to use sequences that can be fired throughout the game
    /// </summary>
    public class GlobalSequences : Singleton<GlobalSequences>
    {
        /// <summary>
        /// Map of global sequences registered
        /// </summary>
        private Dictionary<string, Sequence> m_SequenceMap = new Dictionary<string, Sequence>();

        /// <summary>
        /// Registers sequence in global map
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sequence"></param>
        /// <returns>True if sequence has been registered successfully, otherwise returns false.</returns>
        public bool RegisterSequence(string id, Sequence sequence)
        {
            // check if sequence has not been registered
            if (m_SequenceMap.ContainsKey(id))
            {
                return false;
            }
            // add sequence to map
            m_SequenceMap.Add(id, sequence);
            return true;
        }

        /// <summary>
        /// Unregister sequence with given id from global map
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if sequence has been removed successfully, otherwise returns false.</returns>
        public bool UnregisterSequence(string id)
        {
            return m_SequenceMap.Remove(id);
        }

        /// <summary>
        /// Activates sequence in global map with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if sequence was successfully activated, otherwise returns false.</returns>
        public bool ActivateSequence(string id)
        {
            Sequence sequence = null;
            if(!m_SequenceMap.TryGetValue(id, out sequence))
            {
                return false;
            }
            StartCoroutine("RunSequence", sequence);
            return true;
        }

        private IEnumerator RunSequence(Sequence sequence)
        {
            Status status = Status.Continue;
            while(status == Status.Continue)
            {
                sequence.Execute(ref status);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
