using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace GamesInAdvent.Frogger
{
    public class TextUpdater : MonoBehaviour
    {
        [SerializeField] private GameManager m_gameManager;
        public bool lives;
        private int lastValue;
        private TextMeshProUGUI text;
        private void Start() 
        {
            text = GetComponent<TextMeshProUGUI>();
            if(lives == true)
                lastValue = m_gameManager.lives;
            else lastValue = m_gameManager.score;
        }
        
        private void Update() 
        {
            if(m_gameManager == null)
            {
                return;
            }
            if(lives && lastValue != m_gameManager.lives)
            {
                text.text = m_gameManager.lives.ToString();
                lastValue = m_gameManager.lives;
            }
            else if(!lives && lastValue != m_gameManager.score)
            {
                text.text = m_gameManager.score.ToString();
                lastValue = m_gameManager.score;
            }

        }
    }
}