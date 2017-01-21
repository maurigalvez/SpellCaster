using UnityEngine;
using System.Collections;
namespace Logic
{
    public class StatsManager : Singleton<StatsManager>
    {
        [SerializeField]
        private IntVar m_TotalCoins = null;

        public void AddPoints(int points)
        {
            m_TotalCoins.Value = (int)m_TotalCoins.Value + points;
        }
    }
}
