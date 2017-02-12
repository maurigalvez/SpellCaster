/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Logic
{
    /// <summary>
    /// Interpolate between initial and final intvalues
    /// </summary>
    public class LerpInt : LerpAction
    {
        [SerializeField,HideInInspector]
        public IntVar m_Number = null;

        [SerializeField,HideInInspector]
        public VariableType m_InitialValueType = VariableType.Constant;

        [SerializeField, HideInInspector]
        public int m_InitialValue = 0;
        [SerializeField, HideInInspector]
        public IntVar m_InitialValueVar = null;
        [SerializeField, HideInInspector]
        public string m_InitialValueID = "";

        [SerializeField, HideInInspector]
        public VariableType m_FinalValueType = VariableType.Constant;
        [SerializeField, HideInInspector]
        public int m_FinalValue = 0;
        [SerializeField, HideInInspector]
        public IntVar m_FinalValueVar = null;
        [SerializeField, HideInInspector]
        public string m_FinalValueID = "";

        protected override IEnumerator Interpolate()
        {
            // ---------
            // validate and define values
            // ---------
            // obtain initial value
            if(m_InitialValueType == VariableType.ObjectVar)
            {
                m_InitialValue = (int)m_InitialValueVar.Value;
            }
            else if(m_InitialValueType == VariableType.GlobalVariable)
            {
                m_InitialValue = (int)GlobalVariables.Instance.GetValue(m_InitialValueID);
            }
            // obtain final value
            if (m_FinalValueType == VariableType.ObjectVar)
            {
                m_FinalValue = (int)m_FinalValueVar.Value;
            }
            else if (m_FinalValueType == VariableType.GlobalVariable)
            {
                m_FinalValue = (int)GlobalVariables.Instance.GetValue(m_FinalValueID);
            }
            // ---------
            // Interpolate
            // ---------
            if (m_Number == null)
            {
                m_CurrentStatus = Status.Error;
            }
            else
            {
                float elapsed = 0;
                while (elapsed < m_Time)
                {
                    elapsed += Time.fixedDeltaTime;
                    m_Number.Value = (int)(Mathf.Lerp(m_InitialValue, m_FinalValue, elapsed / m_Time));
                    yield return null;
                }
                m_CurrentStatus = Status.Success;
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(LerpInt))]
    public class LerpIntEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LerpInt self = target as LerpInt;
            //----------
            // set number value
            //----------
            self.m_Number = (IntVar)EditorGUILayout.ObjectField("Number Value", self.m_Number, typeof(IntVar), true);
            //----------
            // set initial value type
            //----------
            self.m_InitialValueType = (Logic.VariableType)EditorGUILayout.EnumPopup("Initial Value Type", self.m_InitialValueType);
            switch (self.m_InitialValueType)
            {
                case VariableType.ObjectVar:
                    self.m_InitialValueVar = (IntVar)EditorGUILayout.ObjectField("Initial Value", self.m_InitialValueVar, typeof(IntVar), true);
                    break;

                case VariableType.GlobalVariable:
                    self.m_InitialValueID = EditorGUILayout.TextField("Initial Value ID", self.m_InitialValueID);
                    break;

                default:
                    self.m_InitialValue = EditorGUILayout.IntField("Initial Value", self.m_InitialValue);
                    break;
                   
            }
            //----------
            // set final value type
            //----------
            self.m_FinalValueType = (Logic.VariableType)EditorGUILayout.EnumPopup("Final Value Type", self.m_FinalValueType);
            switch (self.m_FinalValueType)
            {
                case VariableType.ObjectVar:
                    self.m_FinalValueVar = (IntVar)EditorGUILayout.ObjectField("Final Value", self.m_FinalValueVar, typeof(IntVar), true);
                    break;

                case VariableType.GlobalVariable:
                    self.m_FinalValueID = EditorGUILayout.TextField("Final Value ID", self.m_FinalValueID);
                    break;

                default:
                    self.m_FinalValue = EditorGUILayout.IntField("Final Value", self.m_FinalValue);
                    break;
            }
        }
    }
#endif
}
