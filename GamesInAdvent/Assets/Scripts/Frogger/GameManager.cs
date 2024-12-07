using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GamesInAdvent.Frogger
{
    public class GameManager : MonoBehaviour
    {
        public int lives = 5;
        public int score = 0;
        

        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}