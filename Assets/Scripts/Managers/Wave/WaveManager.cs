/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Logic
{
    /// <summary>
    /// Struct used to specify different spawn rates for a wave.
    /// </summary>
    [System.Serializable]
    struct WaveSpawnStage
    {
        [SerializeField]
        public float Time;
        [SerializeField]
        public Vector2 SpawnRate; 
    }
    /// <summary>
    /// Manager in charge of executing spawn of enemies actions and updating timers.
    /// </summary>
    public class WaveManager : Singleton<WaveManager>
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
        [Tooltip("Spawn rate stages based in time")]
        [SerializeField]
        private WaveSpawnStage[] m_SpawnStages;

        private int m_CurrentSpawnStage = 0;

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
        [SerializeField]
        private string m_WaveNumberDisplayID = "";
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

        /// <summary>
        /// Number of entities spawned that were destroyed
        /// </summary>
        private int m_WaveEntitiesDestroyed = 0;

        private Image m_TimerBar = null;
        //private Text m_TimeDisplay = null;
        /// <summary>
        /// Display for wave number
        /// </summary>
        private Text m_NumberDisplay = null;

        public delegate void WaveBeginEvent();

        /// <summary>
        /// Initialize Wave Manager
        /// </summary>
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
            // obtain number display
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
            }
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
            // hook stop wave when game is over
            GameManager.Instance.OnGameOver += StopWaves;
            StartCoroutine("WaitForNextWave");      
        }

        /// <summary>
        /// Updates number display with current wave number
        /// </summary>
        private void UpdateWaveNumberDisplay()
        {
            m_NumberDisplay.text = m_CurrentWaveNumber.Value.ToString() + " / " + m_NumberOfWaves;
        }

        /// <summary>
        /// Updates time display with current timer value
        /// </summary>
        /*private void UpdateTimeDisplay()
        {
            float timer = (float)m_Timer.Value;
            m_TimeDisplay.text = timer.ToString("00");
        }*/

        /// <summary>
        /// Updates timer and time for next spawn. Passes to next event once timer runs out
        /// </summary>
        private IEnumerator UpdateWave()
        {
            int currentWave = (int)m_CurrentWaveNumber.Value + 1;
            int spawnedEnemies = 0;
            m_CurrentWaveNumber.Value = currentWave;
            // Reset timer
            float timer = m_TimePerWaveInSeconds;
            // reset spawn rate
            m_CurrentSpawnStage = 0;
            // obtain spawn time from current index
            float nextSpawnTime = Random.Range(m_SpawnStages[m_CurrentSpawnStage].SpawnRate.x, m_SpawnStages[m_CurrentSpawnStage].SpawnRate.y);
            // check if timer hasn't run out
            while (timer > 0)
            {
                yield return new WaitForSeconds(1);
                // update timer
                timer--;
                m_Timer.Value = timer;
                m_TimerBar.fillAmount = timer / m_TimePerWaveInSeconds;
                // update spawn time
                nextSpawnTime -= (1 + m_SpawnDecrementPerWave * currentWave);
                Debug.Log(nextSpawnTime);
                // Update wave stage
                UpdateWaveStage(timer);
                // check if spawn time has run out
                if(nextSpawnTime <= 0)
                {
                    // add to entity spawned counter
                    spawnedEnemies++;
                    // fire spawn action 
                    m_SpawnAction.Enter();
                    m_SpawnAction.UpdateNode();
                    m_SpawnAction.Exit();
                    // calculate next spawn time
                    nextSpawnTime = Random.Range(m_SpawnStages[m_CurrentSpawnStage].SpawnRate.x, m_SpawnStages[m_CurrentSpawnStage].SpawnRate.y);
                }
            }
            // wait until all enemies have been destroyed
            while(spawnedEnemies > m_WaveEntitiesDestroyed)
            {
                yield return new WaitForFixedUpdate();
            }
            // reset wave entities destroyed
            m_WaveEntitiesDestroyed = 0;
            // Fire delay for next waave
            StartCoroutine("WaitForNextWave");
        }

        /// <summary>
        /// Fired when entity spawned by wave is destroyed
        /// </summary>
        public void WaveEntityDestroyed()
        {
            m_WaveEntitiesDestroyed++;
        }

        /// <summary>
        /// Updates index of current wave stage
        /// </summary>
        /// <param name="currentTime"></param>
        private void UpdateWaveStage(float currentTime)
        {
            // validate index
            if (m_CurrentSpawnStage < m_SpawnStages.Length - 1)
            {
                // check if index should increment for next avaiable stage
                if(currentTime <= m_SpawnStages[m_CurrentSpawnStage + 1].Time)
                {
                    // increase index
                    m_CurrentSpawnStage++;
                }
            }
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
                    m_EndSequence.UpdateNode();
                }
            }
            else
            {
                // Launch waitfor wave sequence
                if (m_OnWaitForWave != null)
                {
                    m_OnWaitForWave.UpdateNode();
                }
                yield return new WaitForSeconds(m_DelayBeforeWave);
                // Launch on wave begins sequence
                if(m_OnWaveBegins != null)
                {
                    m_OnWaveBegins.UpdateNode();
                }
                StartCoroutine("UpdateWave");
            }
        }

        /// <summary>
        /// Stop all functions
        /// </summary>
        private void StopWaves()
        {
            StopAllCoroutines();
        }
    }
}
