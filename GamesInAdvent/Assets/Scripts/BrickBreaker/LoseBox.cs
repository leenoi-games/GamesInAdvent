using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamesInAdvent.BrickBreaker
{
    public class LoseBox : MonoBehaviour
    {
        [SerializeField] IntVariable m_score;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            m_score.SetValue(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

