using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

namespace GamesInAdvent.Snake
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private UIManager m_uiManager;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_gridSize;
        [SerializeField] private Grid m_grid;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        private int m_score;
        private InputActions m_inputActions;
        private InputAction m_move;
        private Vector2 m_newDirection;
        private Vector2 m_currentDirection;
        private bool m_moveExecuted;
        private float m_scale;
        private Transform m_transform;
        private int m_snakeSize;

        public float Speed{get => m_speed;}
        public int Size{get => m_snakeSize;}


        [SerializeField] int snakeLength;
        private float m_nextUpdate;

        private void Awake() 
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable() 
        {
            m_move = m_inputActions.Sneak.Move;
            m_move.Enable();
            m_move.performed += OnMove;
        }

        private void OnDisable() 
        {
            m_move.Disable();
        }

        private void Start() 
        {
            m_scale = transform.localScale.x;
            m_moveExecuted = false;
            m_scale = transform.localScale.y;

            //Start in lower left corner
            //float pos = -m_gridSize/2 + m_scale/2;
            //transform.position = new Vector2(pos, pos);
            m_transform = transform;

            m_currentDirection = Vector2.up;
            m_snakeSize = 1;
            m_score = 0;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Transform playerpos = transform;
            if(context.performed)
            {
                m_newDirection = m_move.ReadValue<Vector2>().normalized;
                m_moveExecuted = true;
            }
        }

        private void FixedUpdate() 
        {
            if(Time.time < m_nextUpdate) return;
            if(m_newDirection != Vector2.zero)
            m_currentDirection = m_newDirection;

            int moveX = Mathf.RoundToInt(transform.position.x) + (int)m_currentDirection.x;
            int moveY = Mathf.RoundToInt(transform.position.y) + (int)m_currentDirection.y;
            m_transform.position = new Vector2(moveX, moveY);
            m_nextUpdate = Time.time + (1f/m_speed);
        }

        public void Grow()
        {
            m_snakeSize ++;
            m_score++;
            UpdateScore();
            m_grid.SpawnFruit();
        }

        public void UpdateScore()
        {
            m_scoreText.text = m_score.ToString();
        }

        public void Lose()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
