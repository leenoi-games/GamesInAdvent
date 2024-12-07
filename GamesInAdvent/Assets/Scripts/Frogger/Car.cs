using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
namespace GamesInAdvent.Frogger
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        [SerializeField] private FloatVariable m_xBoundry;
        private Transform m_transform;

        private void Start() 
        {
            m_transform = transform;
        }

        private void Update()
        {
            m_transform.position = new Vector2(m_speed * Time.deltaTime + m_transform.position.x, m_transform.position.y);
            if((m_transform.position.x >= m_xBoundry.GetValue() + 10)||(m_transform.position.x <= -m_xBoundry.GetValue() - 10))
            {
                Destroy(gameObject);
            }
        }
    }
}