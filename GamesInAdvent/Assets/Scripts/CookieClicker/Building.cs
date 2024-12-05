using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.CookieClicker
{
    [CreateAssetMenu(menuName= "Cookieclicker/Building")]
    public class Building : ScriptableObject
    {
        [SerializeField] private List<int> m_cost;
        [SerializeField] private float m_cookiesPerSecond;
        private int m_currentBuildingCostIdx;

        public float Cps {get => m_cookiesPerSecond;}

        public void ResetBuilding()
        {
            m_currentBuildingCostIdx = 0;
        }

        public int GetCurrentCost()
        {
            if(m_currentBuildingCostIdx < m_cost.Count)
            {
                return m_cost[m_currentBuildingCostIdx];
            }
            else return m_currentBuildingCostIdx * m_cost[m_cost.Count-1];
        }

        public float Build()
        {
            m_currentBuildingCostIdx++;
            return m_cookiesPerSecond;
        }
    }
}
