using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GamesInAdvent.Util;

namespace GamesInAdvent.Jetpack
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_jumpForce = 3f;
        //[SerializeField] private GameManager m_gameManager;
        
        private InputActions m_inputActions;
        private InputAction m_jump;
        private Rigidbody2D m_rb;
        private bool m_isFlying;
        private Coroutine m_movementProcess;
        [SerializeField] private IntVariable m_coins;

        [SerializeField] private ParticleSystem m_particleSystem;

        private void Awake() 
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable() 
        {
            m_jump = m_inputActions.Jetpack.Fly;
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
            m_isFlying = false;
            m_coins.SetValue(0);
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed && m_isFlying == false)
            {
                m_isFlying = true;
                Debug.Log("Flying");
                m_particleSystem.Play();
                if(m_movementProcess != null) this.StopCoroutine(this.m_movementProcess);
                this.m_movementProcess = StartCoroutine(Flying(context));
            }
        }

        private IEnumerator Flying(InputAction.CallbackContext context)
        {
            while (m_isFlying == true)
            {
                if(context.ReadValue<float>() < 0.3f)
                {
                    m_isFlying = false;
                    m_rb.velocity = new Vector2(0, -m_jumpForce);
                    m_particleSystem.Stop();
                    break;
                }
                m_rb.velocity = new Vector2(0, m_jumpForce);
                
                yield return null;
            }
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //m_gameManager?.OnLose();
        }

        /*private void Update() 
        {
            if(m_isFlying == true)
            {
                m_rb.velocity = new Vector2(0, m_jumpForce);
            }
        }*/
    }
}

