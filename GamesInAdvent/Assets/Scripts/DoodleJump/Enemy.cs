using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.DoodleJump
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private LevelManager m_LevelManager;
        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Player"))
            {
                m_LevelManager.Death();
            }
            //Destroy(other.gameObject);
        }
    }

}
