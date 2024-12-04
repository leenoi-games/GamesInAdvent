using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
using TMPro;

namespace GamesInAdvent.CookieClicker
{
    public class BuildingShop : MonoBehaviour
    {
        [SerializeField] private FloatVariable m_numberOfCookies;
        [SerializeField] private FloatVariable m_cps;
        [SerializeField] private Building m_building;
        [SerializeField] private TextMeshProUGUI m_text;
        private void Start() 
        {
            m_building.ResetBuilding();
            m_text.text = "Cost: " + m_building.GetCurrentCost();
        }
        public void BuyBuilding()
        {
            if (m_building.GetCurrentCost() < m_numberOfCookies.GetValue())
            {   
                m_numberOfCookies.SetValue(m_numberOfCookies.GetValue() - m_building.GetCurrentCost());
                m_cps.SetValue(m_cps.GetValue() + m_building.Cps);
                m_building.Build();
                m_text.text = "Cost: " + m_building.GetCurrentCost();
            }
        }
    }
}

