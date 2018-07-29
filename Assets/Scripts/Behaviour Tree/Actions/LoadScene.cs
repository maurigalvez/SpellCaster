/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
namespace Logic
{
   
    /// <summary>
    /// Action used to load a new scene
    /// </summary>
    public class LoadScene : Action
    {
        [SerializeField]
        private string m_SceneName;

        enum Mode
        {
            Default = 0,
            Async
        }
        [SerializeField]
        private Mode m_LoadMode = Mode.Default;

        [SerializeField]
        private LoadSceneMode m_LoadSceneMode = LoadSceneMode.Single;

        protected override Status UpdateNode()
        {
            if(m_LoadMode == Mode.Default)
            {
                SceneManager.LoadScene(m_SceneName);
            }
            else
            {
                SceneManager.LoadSceneAsync(m_SceneName, m_LoadSceneMode);
            }
            return Status.Success;
        }
    }
}
