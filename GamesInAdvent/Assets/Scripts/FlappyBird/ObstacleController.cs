using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.FlappyBird
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        private Transform m_transform;

        private void Start() 
        {
            m_transform = gameObject.transform;    
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = new Vector2(m_transform.position.x - m_speed * Time.deltaTime, m_transform.position.y);
        }
    }
}

