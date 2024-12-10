using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GamesInAdvent.Util;

namespace GamesInAdvent.Jetpack
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] IntVariable m_coins;
        [SerializeField] IntVariable m_score;

        [SerializeField] TextMeshProUGUI m_coinText;
        [SerializeField] TextMeshProUGUI m_scoreText;

        private int m_oldCoins;
        private int m_oldScore;
        private void Start() 
        {
            m_oldCoins = m_coins.GetValue();
            m_oldScore = m_score.GetValue();
        }

        private void Update() 
        {
            if(m_oldCoins != m_coins.GetValue())
            {
                m_oldCoins = m_coins.GetValue();
                m_coinText.text = m_oldCoins.ToString();
            }
            if(m_oldScore != m_score.GetValue())
            {
                m_oldScore = m_score.GetValue();
                m_scoreText.text = m_oldScore.ToString();
            }
        }


    }
}