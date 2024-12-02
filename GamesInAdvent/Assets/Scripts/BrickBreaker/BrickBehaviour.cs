using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;

namespace GamesInAdvent.BrickBreaker
{
    public class BrickBehaviour : MonoBehaviour
    {
        [SerializeField] int m_lives = 1;
        [SerializeField] IntVariable score;

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Ball"))
            {
                m_lives--;
                score.SetValue(score.GetValue() + 1);
                if(m_lives == 0) Destroy(gameObject);
            }
        }
    }
}

