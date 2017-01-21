/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;
namespace Logic
{
    /// <summary>
    /// Condition used to check if there's a collision in direction from ray to camera to screen point in world space
    /// </summary>
    public class CameraRaycastCondition : Condition
    {
        [SerializeField]
        private Camera m_Camera = null;

        [SerializeField]
        private LayerMask m_LayerMask;

        [SerializeField]
        private float m_Distance = 10.0f;

        [SerializeField]
        private Vector3Var m_ScreenPoint = null;

        [SerializeField]
        private Vector3Var m_HitPoint = null;

        private RaycastHit m_Hit = new RaycastHit();
        private Ray m_Ray = new Ray();


        public override Status ValidateCondition()
        {
            if (m_Camera == null || m_ScreenPoint == null)
            {
                return Status.Error;
            }
            m_Ray = m_Camera.ScreenPointToRay((Vector3)m_ScreenPoint.Value);
            // check if there's a raycast 
            if (Physics.Raycast(m_Ray, out m_Hit, m_Distance, m_LayerMask))
            {
                // store hitpoint if variable was provided
                if(m_HitPoint)
                {
                    m_HitPoint.Value = m_Hit.point;
                }
                return Status.Success;
            }
            return Status.Failure;
        }

        private void OnDrawGizmos()
        {
           Gizmos.DrawRay(m_Ray);   
        }
    }
}