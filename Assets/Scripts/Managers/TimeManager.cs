/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// Pause/Freeze game
        /// </summary>
        public void Pause()
        {
            Time.timeScale = 0;
        }        
        /// <summary>
        /// Resume/unfreeze game
        /// </summary>
        public void Resume()
        {
            Time.timeScale = 1;
        }
        /// <summary>
        /// Set time scale to given time scale
        /// </summary>
        /// <param name="timeScale">assign timescale of game</param>
        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}
