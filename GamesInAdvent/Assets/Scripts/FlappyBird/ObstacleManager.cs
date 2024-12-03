using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.FlappyBird
{
    public class ObstacleManager : MonoBehaviour
    {
        [SerializeField] private float m_spawnTimer;
        [SerializeField] private Vector3 m_SpawnPos;
        [SerializeField] private List<GameObject> m_obstacles;

        private float m_lastSpawnTime;

        private void Start() 
        {
            m_lastSpawnTime = 0;
        }

        private void Update() 
        {
            m_lastSpawnTime += Time.deltaTime;
            if(m_lastSpawnTime >= m_spawnTimer)
            {
                int obstacleindex = Random.Range(0, m_obstacles.Count);
                Instantiate(m_obstacles[obstacleindex], m_SpawnPos, Quaternion.identity);
                m_lastSpawnTime = 0;
            }
        }
    }
}

