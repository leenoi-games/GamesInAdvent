using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GamesInAdvent.FlappyBird
{
    public class BirdController : MonoBehaviour
    {
        [SerializeField] private float m_jumpForce = 10f;
        [SerializeField] private GameManager m_gameManager;
        
        private InputActions m_inputActions;
        private InputAction m_jump;
        private Rigidbody2D m_rb;
        private SpriteRenderer m_spriteRenderer;
        [SerializeField] private Sprite m_bird1;
        [SerializeField] private Sprite m_bird2;
        private bool m_flip = true;

        private float m_moveDirection = 0f;

        private void Awake() 
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable() 
        {
            m_jump = m_inputActions.FlappyBird.Jump;
            m_jump.Enable();
            m_jump.performed += OnJump;
        }

        private void OnDisable() 
        {
            m_jump.Disable();
        }

        private void Start() 
        {
            m_rb = GetComponent<Rigidbody2D>();  
            m_spriteRenderer = GetComponent<SpriteRenderer>();  
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpForce);
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            Debug.Log("Game Over");
            m_gameManager?.OnLose();
        }

        private void Update() 
        {

            if(m_rb.velocity.y >= 0 && m_flip == false)
            {
                m_flip = true;
            }
            if(m_rb.velocity.y <= 0 && m_flip == false)
            {
                m_flip = false;
            }
        }


    }
}

