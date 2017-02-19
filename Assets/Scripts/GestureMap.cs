/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Logic
{
    [System.Serializable]
    public class GestureEvent
    {
        [SerializeField]
        public string GestureName = null;
        [SerializeField]
        public BehaviourNode OnRecognize = null;
    }

    public class GestureMap : MonoBehaviour
    {
        [SerializeField]
        public List<GestureEvent> GestureEvents = new List<GestureEvent>();

        [SerializeField]
        private Dictionary<string, BehaviourNode> m_GestureEventMap;

        [SerializeField]
        public Vector3Var m_GestureCenter = null;

        private void OnEnable()
        {
            GestureBehaviour.OnGestureRecognition += OnGestureRecognition;
        }

        private void Awake()
        {
            StartCoroutine("InitializeMap");
        }

        private void OnDisable()
        {
            GestureBehaviour.OnGestureRecognition -= OnGestureRecognition;
        }

        private void OnGestureRecognition(Gesture gesture, Result result)
        {
            // obtain node to run
            BehaviourNode gestureEvent = null;
            if(m_GestureEventMap.TryGetValue(result.Name,out gestureEvent))
            {
                if(m_GestureCenter)
                {
                    Vector3 center = gesture.GetScreenCenterPosition();
                    m_GestureCenter.Value = center;
                }
                gestureEvent.Execute();
            }
        }

        /// <summary>
        /// Coroutine used to initialize map
        /// </summary>
        private IEnumerator InitializeMap()
        {
            m_GestureEventMap = new Dictionary<string, BehaviourNode>();           
            for (int gestureIndex = 0; gestureIndex < GestureEvents.Count; gestureIndex++)
            {               
                m_GestureEventMap.Add(GestureEvents[gestureIndex].GestureName, GestureEvents[gestureIndex].OnRecognize);
            }
            yield return null;
        }

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GestureMap))]
    public class GestureMapEditor: Editor
    {
        private GestureEvent m_GestureEvent = null;

        public override void OnInspectorGUI()
        {
            GestureMap self = target as GestureMap;
            // Get gesture center store
            self.m_GestureCenter = EditorGUILayout.ObjectField("Gesture Center Screen Point: ", self.m_GestureCenter, typeof(Vector3Var), true) as Vector3Var;
            // add a new gesture event
            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Gesture Events");
                if (GUILayout.Button("Add new gesture event"))
                {
                    self.GestureEvents.Add(new GestureEvent());
                }
            EditorGUILayout.EndHorizontal();
            // Edit list of gesture events
            for(int eventIndex = 0; eventIndex < self.GestureEvents.Count; eventIndex++)
            {
                // cache current event index
                m_GestureEvent = self.GestureEvents[eventIndex];
                // display name - parameters - remove
                EditorGUILayout.BeginHorizontal();
                // -----
                // NAME
                // ----
                    if(m_GestureEvent== null && m_GestureEvent.GestureName.Length == 0)
                    {
                        EditorGUILayout.LabelField(eventIndex.ToString(),EditorStyles.boldLabel);
                    }
                    else
                    {
                        EditorGUILayout.LabelField(m_GestureEvent.GestureName, EditorStyles.boldLabel);
                    }
                    if (GUILayout.Button("-"))
                    {
                        self.GestureEvents.RemoveAt(eventIndex);
                        return;
                    }
                EditorGUILayout.EndHorizontal();
                // -----
                // PARAMETERS
                // ------             
                m_GestureEvent.GestureName = EditorGUILayout.TextField("Gesture ID:", m_GestureEvent.GestureName);
                m_GestureEvent.OnRecognize = EditorGUILayout.ObjectField("Event: ", m_GestureEvent.OnRecognize, typeof(Sequence), true) as Sequence;                         
            }
        }
    }
#endif
}
