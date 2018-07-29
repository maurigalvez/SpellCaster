using UnityEngine;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Action used to set playback speed of animator
    /// </summary>
    public class SetAnimationSpeed : Action
    {
        [SerializeField]
        private Animator m_Animator = null;

        [SerializeField]
        private float m_PlaybackSpeed = 1.0f;

        [SerializeField]
        private Vector2 m_SpeedRange = Vector2.zero;

        protected override Status UpdateNode()
        {
            // validate
            if(m_Animator == null)
            {
                return Status.Error;
            }
            if (m_SpeedRange != Vector2.zero)
            {
                m_Animator.speed = Random.Range(m_SpeedRange.x, m_SpeedRange.y);
            }
            else
            {
                m_Animator.speed = m_PlaybackSpeed;
            }
            return Status.Success;
        }
    }
}
