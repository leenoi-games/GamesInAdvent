using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.BrickBreaker
{
    public class BallMovement : MonoBehaviour
    {
        private Rigidbody2D m_rb;
        [SerializeField] float m_speed = 10f;
        void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_rb.velocity = new Vector2(m_speed, m_speed);
        }
    }
}

