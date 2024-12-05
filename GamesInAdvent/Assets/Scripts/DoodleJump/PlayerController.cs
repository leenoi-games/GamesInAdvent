using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GamesInAdvent.DoodleJump
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private float m_jumpStrength;
        private InputActions m_inputActions;
        private InputAction m_move;
        private Rigidbody2D m_rb;

        private float m_moveDirection = 0f;

        private void Awake() 
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable() 
        {
            m_move = m_inputActions.DoodleJump.Move;
            m_move.Enable();
        }

        private void OnDisable() 
        {
            m_move.Disable();
        }

        private void Start() 
        {
            m_rb = GetComponent<Rigidbody2D>();    
        }
        private void Update() 
        {
            m_moveDirection = m_move.ReadValue<float>();
            m_rb.velocity = new Vector2(m_moveDirection * m_moveSpeed, m_rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Platform"))
            {
                m_rb.velocity = new Vector2(m_moveDirection * m_moveSpeed, m_jumpStrength);
            }
        }
    }
}

