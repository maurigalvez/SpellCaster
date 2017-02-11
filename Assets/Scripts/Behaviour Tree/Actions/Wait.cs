/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Logic
{
    /// <summary>
    /// Used to add a delay between nodes
    /// </summary>
    public class Wait : Action
    {
        [SerializeField]
        public VariableType m_VariableType;

        /// <summary>
        /// Time that delay will last for
        /// </summary>
        [SerializeField]
        public float m_TimeInSeconds = 3.0f;

        /// <summary>
        /// Float var instance 
        /// </summary>
        [SerializeField]
        public FloatVar m_TimeVarInSeconds = null;

        /// <summary>
        /// Name of time variable id
        /// </summary>
        [SerializeField]
        public string m_TimeVariableID = "";

        /// <summary>
        /// Current status of action
        /// </summary>
        private Status m_CurrentStatus = Status.Error;

        public override void Enter()
        {
            // check if time value comes from floatvar
            switch (m_VariableType)
            {
                case VariableType.GlobalVariable:
                    object value = GlobalVariables.Instance.GetValue(m_TimeVariableID);
                    if(value == null)
                    {
                        m_CurrentStatus = Status.Error;
                        return;
                    }
                    m_TimeInSeconds = (float)value;
                    break;

                case VariableType.ObjectVar:
                    if(m_TimeVarInSeconds == null)
                    {
                        m_CurrentStatus = Status.Error;
                        return;
                    }
                    m_TimeInSeconds = (float)m_TimeVarInSeconds.Value;
                    break;
            }            
            StartCoroutine("UpdateTimer");
        }

        public override Status UpdateNode()
        {
            return m_CurrentStatus;
        }

        private IEnumerator UpdateTimer()
        {
            m_CurrentStatus = Status.Running;
            yield return new WaitForSeconds(m_TimeInSeconds);
            m_CurrentStatus = Status.Success;
        }

        public override void Exit()
        {
            m_CurrentStatus = Status.Error;
        }

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Wait))]
    public class WaitEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            // obtain type 
            Wait self = target as Wait;
            // obtain variable type
            self.m_VariableType = (VariableType)EditorGUILayout.EnumPopup("Variable Type: ", self.m_VariableType);

            // define value based on type
            switch(self.m_VariableType)
            {
                case VariableType.GlobalVariable:
                    self.m_TimeVariableID = EditorGUILayout.TextField("Time Variable ID :", self.m_TimeVariableID);
                    break;

                case VariableType.ObjectVar:
                    self.m_TimeVarInSeconds = (FloatVar)EditorGUILayout.ObjectField("Time Variable: ", self.m_TimeVarInSeconds,typeof(FloatVar),true);
                    break;

                default:
                    self.m_TimeInSeconds = EditorGUILayout.FloatField("Time In Seconds: ", self.m_TimeInSeconds);
                    break;
            }
        }
    }
#endif
}
