using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamesInAdvent.FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private IntVariable m_score;
        public void OnLose()
        {
            m_score.SetDefault();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

