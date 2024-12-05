using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.DoodleJump;
using UnityEngine;

namespace GamesInAdvent.DoodleJump
{
    public class EndOfLevel : MonoBehaviour
    {
        [SerializeField] private LevelManager m_LevelManager;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                m_LevelManager.SpawnNewLevel();
            }
        }
    }
}

