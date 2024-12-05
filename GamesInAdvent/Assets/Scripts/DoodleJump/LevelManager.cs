using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamesInAdvent.DoodleJump
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> levels;
        public void Death()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void SpawnNewLevel()
        {
            int random = Random.Range(0, levels.Count - 1);
            //Instantiate(levels[random], transform.position, transform.rotation);
        }
    }
}