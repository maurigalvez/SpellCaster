using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Manager in charge of executing spawn of enemies actions and updating timers.
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        /// <summary>
        /// Total number of waves
        /// </summary>
        [SerializeField]
        private int m_NumberOfWaves = 3;
        /// <summary>
        /// Time for each wave in seconds
        /// </summary>
        [SerializeField]
        private float m_TimePerWaveInSeconds = 30;
        /// <summary>
        /// Delay between waves in seconds
        /// </summary>
        [SerializeField]
        private float m_DelayBeforeWave = 5.0f;
        /// <summary>
        /// Range that will be used to spawn enemies between waves.
        /// </summary>
        [Tooltip("Time In Seconds between entities spawn")]
        [SerializeField]
        private Vector2 m_SpawnTimeRangeInSeconds = new Vector2(2, 5);

        [Tooltip("Percentage that will be ducked from time from entity spawn every wave.")]
        [SerializeField]
        private float m_SpawnDecrementPerWave = 10;
        /// <summary>
        /// Storage for current wave number
        /// </summary>
        [SerializeField]
        private IntVar m_CurrentWaveNumber = null;
        /// <summary>
        /// ID of UI text that will display wave number
        /// </summary>
        /*[SerializeField]
        private string m_WaveNumberDisplayID = "";*/
        /// <summary>
        /// Storage for current float var
        /// </summary>
        [SerializeField]
        private FloatVar m_Timer = null;
        /// <summary>
        /// ID of UI text that will display timer ID
        /// </summary>
        [SerializeField]
        private string m_TimerBarID = "";      
        /// <summary>
        /// Action used to spawn entities
        /// </summary>
        [SerializeField]
        private SpawnObject m_SpawnAction = null;

        [SerializeField]
        private Sequence m_OnWaitForWave = null;

        [SerializeField]
        private Sequence m_OnWaveBegins = null;

        [SerializeField]
        private Sequence m_EndSequence = null;
        /// <summary>
        /// Time in seconds until next spawn action execution
        /// </summary>
        private float m_TimeUntilNextSpawn = 0;
        private Image m_TimerBar = null;
        //private Text m_TimeDisplay = null;
        //private Text m_NumberDisplay = null;

        private void Start()
        {
            // validate spawn action
            if (m_SpawnAction == null)
            {
                Debug.LogError("[ERROR] WaveManager: No spawn action was assigned!");
                return;
            }
            object timerBar = GlobalVariables.Instance.GetValue(m_TimerBarID);
            if(timerBar != null)
            {
                m_TimerBar = (Image)timerBar;
            }
            if (m_Timer != null)
            {
                m_Timer.Value = m_TimePerWaveInSeconds;               
            }
            /*// obtain number display
            object display = GlobalVariables.Instance.GetValue(m_WaveNumberDisplayID);
            // validate diplay
            if(display != null)
            {
                m_NumberDisplay = (Text)display;
                if(m_CurrentWaveNumber != null)
                {
                    m_CurrentWaveNumber.Value = 0;
                    m_CurrentWaveNumber.OnValueChanged += UpdateWaveNumberDisplay;
                }
            }*/
            // obtain time display
            /*object display = GlobalVariables.Instance.GetValue(m_TimerDisplayID);
            if(display != null)
            {
                m_TimeDisplay = (Text)display;
                if(m_Timer != null)
                {
                    m_Timer.Value = m_TimePerWaveInSeconds;
                    m_Timer.OnValueChanged += UpdateTimeDisplay;
                }
            }*/
            StartCoroutine("WaitForNextWave");
        }

        /// <summary>
        /// Updates number display with current wave number
        /// </summary>
        /*private void UpdateWaveNumberDisplay()
        {
            m_NumberDisplay.text = m_CurrentWaveNumber.ToString();
        }

        /// <summary>
        /// Updates time display with current timer value
        /// </summary>
        private void UpdateTimeDisplay()
        {
            float timer = (float)m_Timer.Value;
            m_TimeDisplay.text = timer.ToString("00");
        }*/

        /// <summary>
        /// Updates timer and time for next spawn. Passes to next event once timer runs out
        /// </summary>
        private IEnumerator UpdateWave()
        {
            m_CurrentWaveNumber.Value = (int)m_CurrentWaveNumber.Value + 1;
            float timer = (float)m_Timer.Value;
            float nextSpawnTime = Random.Range(m_SpawnTimeRangeInSeconds.x, m_SpawnTimeRangeInSeconds.y);
            while (timer > 0)
            {
                yield return new WaitForFixedUpdate();
                // update timer
                timer -= Time.fixedDeltaTime;
                m_Timer.Value = timer;
                m_TimerBar.fillAmount = timer / m_TimePerWaveInSeconds;
                // update spawn time
                nextSpawnTime -= Time.fixedDeltaTime * (1 + m_SpawnDecrementPerWave * 0.01f);
                if(nextSpawnTime <= 0)
                {
                    m_SpawnAction.UpdateAction();
                    nextSpawnTime = Random.Range(m_SpawnTimeRangeInSeconds.x, m_SpawnTimeRangeInSeconds.y);
                }
            }
            StartCoroutine("WaitForNextWave");
        }

        /// <summary>
        /// Waits 3 seconds for next wave.
        /// </summary>
        private IEnumerator WaitForNextWave()
        {
            // check if this is the last wave
            if ((int)m_CurrentWaveNumber.Value == m_NumberOfWaves)
            {
                if (m_EndSequence != null)
                {
                    m_EndSequence.UpdateAction();
                }
            }
            else
            {
                // Launch waitfor wave sequence
                if (m_OnWaitForWave != null)
                {
                    m_OnWaitForWave.UpdateAction();
                }
                yield return new WaitForSeconds(3);
                // Launch on wave begins sequence
                if(m_OnWaveBegins != null)
                {
                    m_OnWaveBegins.UpdateAction();
                }
                StartCoroutine("UpdateWave");
            }
        }
    }
}
