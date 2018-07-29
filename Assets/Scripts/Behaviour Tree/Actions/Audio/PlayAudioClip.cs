using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Logic
{

    /// <summary>
    /// Action used to play an audioclip
    /// </summary>
    public class PlayAudioClip : Action
    {
        [SerializeField]
        public AudioSource m_AudioSource = null;

        [SerializeField]
        public AudioClip m_AudioClip = null;

        [SerializeField]
        public List<AudioClip> m_AudioClips = new List<AudioClip>();

        [SerializeField]
        public bool m_PlayRandomClip = false;

        protected override Status UpdateNode()
        {
            // validate source
            if (m_AudioSource == null)
            {
                return Status.Error;
            } 
            // validate mode + clips
            if(m_PlayRandomClip && m_AudioClips.Count == 0)
            {
                return Status.Error;
            }  
            else if(!m_PlayRandomClip && m_AudioClip == false)
            {
                return Status.Error;
            }

            if (m_PlayRandomClip)
            {
                m_AudioSource.PlayOneShot(m_AudioClips[Random.Range(0, m_AudioClips.Count)]);
            }
            else
            {
                m_AudioSource.PlayOneShot(m_AudioClip);
            }
            return Status.Success;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PlayAudioClip))]
    public class PlayAudioClipEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            PlayAudioClip self = target as PlayAudioClip;

            // get audio source
            self.m_AudioSource = EditorGUILayout.ObjectField("Audio Source", self.m_AudioSource, typeof(AudioSource), true) as AudioSource;
            // check if its clip will be chosen at random
            self.m_PlayRandomClip = EditorGUILayout.Foldout(self.m_PlayRandomClip, "Play Random Clip");
            if (self.m_PlayRandomClip)
            {
                // -----------
                // LABEL AND ADD AUDIO CLIP
                // -----------
                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Audio Clips",EditorStyles.boldLabel);
                    if(GUILayout.Button("+"))
                    {
                        self.m_AudioClips.Add(null);
                    }
                EditorGUILayout.EndHorizontal();
                // ---------
                // ITERATE AND ASSIGN AUDIO CLIP
                // ---------
                EditorGUI.indentLevel++;
                for (int clipIndex = 0; clipIndex < self.m_AudioClips.Count; clipIndex++)
                {
                    EditorGUILayout.BeginHorizontal();
                    self.m_AudioClips[clipIndex] = EditorGUILayout.ObjectField("Clip " + clipIndex, self.m_AudioClips[clipIndex], typeof(AudioClip), true) as AudioClip;
                    if (GUILayout.Button("-"))
                    {
                        self.m_AudioClips.RemoveAt(clipIndex);
                        return;
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUI.indentLevel--;
            }
            else
            {
                self.m_AudioClip = EditorGUILayout.ObjectField("Clip", self.m_AudioClip, typeof(AudioClip), true) as AudioClip;
            }
        }
    }
#endif
}
