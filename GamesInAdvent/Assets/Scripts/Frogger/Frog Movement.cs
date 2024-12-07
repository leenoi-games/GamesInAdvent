using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GamesInAdvent.Frogger
{
    public class FrogMovement : MonoBehaviour
    {
        [SerializeField] private FloatVariable m_XBoundry;
        [SerializeField] private Vector2 m_respawnPos;
        [SerializeField] private GameManager m_gameManager;
        private float m_size;
        private InputActions m_inputActions;
        private InputAction m_move;
        private void Awake() 
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable() 
        {
            m_move = m_inputActions.Frogger.Move;
            m_move.Enable();
            m_move.performed += OnMove;
        }

        private void OnDisable() 
        {
            m_move.Disable();
        }

        private void Start() 
        {
            m_size = transform.localScale.x;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Transform playerpos = transform;
            if(context.performed)
            {
                Vector2 direction = m_move.ReadValue<Vector2>().normalized;
                if((direction.x > 0 && playerpos.position.x <= m_XBoundry.GetValue())|| (playerpos.position.x >= -m_XBoundry.GetValue() && direction.x < 0) || direction.x == 0)
                {
                    transform.position = new Vector2(playerpos.position.x + direction.x * m_size, playerpos.position.y + direction.y * m_size);
                }   
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("Car"))
            {
                m_gameManager.lives -= 1;
                if (m_gameManager.lives == 0)
                    m_gameManager.ResetLevel();
                transform.position = m_respawnPos;
            }
            else if (other.gameObject.CompareTag("EndOfLevel"))
            {
                m_gameManager.score += 100;
                transform.position = m_respawnPos;
            }
        }

        /*private void OnCollisionEnter2D(Collision2D other) 
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
        }*/

    }
}
