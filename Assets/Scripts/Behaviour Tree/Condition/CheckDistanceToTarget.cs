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
    /// Condition used to check if target is within minimum distance from origin
    /// </summary>
    public class CheckDistanceToTarget : Condition
    {
        /// <summary>
        /// Mode to use to obtain origin value
        /// </summary>
        [SerializeField]
        public VariableType m_OriginType;

        /// <summary>
        /// Transform of object to use as origin
        /// </summary>
        [SerializeField]
        public Transform m_Origin = null;

        [SerializeField]
        public TransformVar m_OriginVar = null;

        [SerializeField]
        public string m_OriginID = "";

        /// <summary>
        /// Mode to use to obtain origin value
        /// </summary>
        [SerializeField]
        public VariableType m_TargetType;

        /// <summary>
        /// Transform of object to use as the target
        /// </summary>
        [SerializeField]
        public Transform m_Target = null;

        [SerializeField]
        public TransformVar m_TargetVar = null;

        [SerializeField]
        public string m_TargetID = "";

        /// <summary>
        /// Minimum distance
        /// </summary>
        [SerializeField]
        public float m_MinimumDistance = 1.0f;

        public override void Enter()
        {
            // set origin transform value
            switch (m_OriginType)
            {
                case VariableType.ObjectVar:
                    // validate
                    if (m_OriginVar == null)
                    {
                        m_Origin = null;
                        return;
                    }
                    m_Origin = (Transform)m_OriginVar.Value;
                    break;

                case VariableType.GlobalVariable:
                    // validate
                    if (m_OriginID.Length == 0)
                    {
                        m_Origin = null;
                        return;
                    }
                    // obtain variable
                    m_Origin = (Transform)GlobalVariables.Instance.GetValue(m_OriginID);
                    break;
            }
          
            // set target transform value
            switch (m_TargetType)
            {
                case VariableType.ObjectVar:
                    // validate
                    if (m_TargetVar == null)
                    {
                        m_Target = null;
                        return;
                    }
                    m_Target = (Transform)m_TargetVar.Value;
                    break;

                case VariableType.GlobalVariable:
                    // validate
                    if (m_TargetID.Length == 0)
                    {
                        m_Target = null;
                        return;
                    }
                    // obtain variable
                    m_Target = (Transform)GlobalVariables.Instance.GetValue(m_TargetID);
                    break;
            }
        }

        public override Status ValidateCondition()
        {
            // validate properties
            if (m_Origin == null || m_Target == null)
            {
                return Status.Error;
            }

            // check distance between origin and target
            if (Vector3.Distance(m_Origin.position,m_Target.position) <= m_MinimumDistance)
            {
                return Status.Success;
            }

            return Status.Failure;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CheckDistanceToTarget))]
    public class CheckDistanceToTargetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CheckDistanceToTarget self = target as CheckDistanceToTarget;

            // obtain origin mode
            self.m_OriginType = (VariableType)EditorGUILayout.EnumPopup("Origin Value: ", self.m_OriginType);
            // set origin value
            switch (self.m_OriginType)
            {
                case VariableType.GlobalVariable:
                    self.m_OriginID = EditorGUILayout.TextField("Origin ID: ", self.m_OriginID);
                    break;

                case VariableType.ObjectVar:
                    self.m_OriginVar = EditorGUILayout.ObjectField("Origin: ", self.m_OriginVar, typeof(TransformVar), true) as TransformVar;
                    break;

                default:
                    self.m_Origin = EditorGUILayout.ObjectField("Origin: ", self.m_Origin, typeof(Transform), true) as Transform;
                    break;
            }

            // obtain target mode
            self.m_TargetType = (VariableType)EditorGUILayout.EnumPopup("Target Value: ", self.m_TargetType);
            // set target value        
            switch (self.m_TargetType)
            {
                case VariableType.GlobalVariable:
                    self.m_TargetID = EditorGUILayout.TextField("Target ID: ", self.m_TargetID);
                    break;

                case VariableType.ObjectVar:
                    self.m_TargetVar = EditorGUILayout.ObjectField("Target: ", self.m_TargetVar, typeof(TransformVar), true) as TransformVar;
                    break;

                default:
                    self.m_Target = EditorGUILayout.ObjectField("Target: ", self.m_Target, typeof(Transform), true) as Transform;
                    break;
            }

            // obtain min distance
            self.m_MinimumDistance = EditorGUILayout.FloatField("Minimum distance: ", self.m_MinimumDistance);
        }
    }
#endif
}
