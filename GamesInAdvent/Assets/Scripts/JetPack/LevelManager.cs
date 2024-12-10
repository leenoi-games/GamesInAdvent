using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;

namespace GamesInAdvent.Jetpack
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_levels;
        [SerializeField] private FloatVariable m_levelSpeed;
        [SerializeField] private float m_initialSpeed;
        [SerializeField] private IntVariable m_score;
        [SerializeField] private float m_speedIncreaseRate;
        private float m_scoreIncrease;

        private void Start() 
        {
            m_levelSpeed.SetValue(m_initialSpeed);
            m_score.SetValue(0);
            m_scoreIncrease = Time.time + (1f/m_levelSpeed.GetValue());

        }

        public void SpawnLevel()
        {
            if(m_levels.Count == 0) return;
            int random = Random.Range(0, m_levels.Count-1);
            Instantiate(m_levels[random], transform.position, transform.rotation);
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("EndOfLevel"))
            {
                Destroy(other.gameObject);
                SpawnLevel();
            }
        }

        private void FixedUpdate() 
        {
            m_levelSpeed.SetValue(m_levelSpeed.GetValue() + m_speedIncreaseRate * Time.deltaTime);
            if(Time.time < m_scoreIncrease) return;
            
            m_score.Increment(1);
            m_scoreIncrease = Time.time + (1f/m_levelSpeed.GetValue());
        }

    }
}