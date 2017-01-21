using UnityEngine;
using System.Collections;
using System;

namespace Logic
{
    /// <summary>
    /// Input Control used to trigger events based on Mouse Input
    /// </summary>
    public class MouseInput : InputControl
    {
        
        protected enum InputMode
        {
            OnHold = 0,
            OnMouseDown,
            OnMouseUp,
        }
        /// <summary>
        /// ID of mouse button
        /// </summary>
        [SerializeField]
        protected int m_MouseButtonID = 0;
        /// <summary>
        /// Mode used to validate input
        /// </summary>
        [SerializeField]
        protected InputMode m_Mode = InputMode.OnMouseDown;
        /// <summary>
        /// Variable instance where input can be stored
        /// </summary>
        [SerializeField]
        protected Vector3Var m_MousePosition = null;
        /// <summary>
        /// If true, it will transform mouse position to world space when stored
        /// </summary>
        [SerializeField]
        protected bool m_PositionInWorldSpace = false;

        public override bool ValidateInput()
        {           
            // Obstain mouse Position
            if(m_MousePosition)
            {
                if (m_PositionInWorldSpace)
                {
                    m_MousePosition.Value = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
                }
                else
                {
                    m_MousePosition.Value = Input.mousePosition;
                }
            }
            // validate input
            switch(m_Mode)
            {
                case InputMode.OnMouseUp:
                    if(Input.GetMouseButtonUp(m_MouseButtonID))
                    {
                        Debug.Log("OnMouseUp");
                        FireEvents();
                        return true;
                    }
                    break;
                case InputMode.OnMouseDown:
                    if (Input.GetMouseButtonDown(m_MouseButtonID))
                    {
                        Debug.Log("OnMouseDown");
                        FireEvents();
                        return true;
                    }
                    break;
                case InputMode.OnHold:
                    if (Input.GetMouseButton(m_MouseButtonID))
                    {
                        Debug.Log("OnMouseButton");
                        FireEvents();
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
