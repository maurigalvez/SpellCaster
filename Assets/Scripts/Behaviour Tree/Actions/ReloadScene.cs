/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Logic
{
    /// <summary>
    /// Action used to reload current scene
    /// </summary>
    public class ReloadScene : Action
    {
        /// <summary>
        /// Mode to reload scene
        /// </summary>
        [SerializeField]
        private LoadSceneMode m_LoadSceneMode = LoadSceneMode.Single;

        public override Status UpdateNode()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, m_LoadSceneMode);
            return Status.Success;
        }
    }
}
