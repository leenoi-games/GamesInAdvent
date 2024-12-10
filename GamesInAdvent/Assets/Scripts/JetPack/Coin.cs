using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
namespace GamesInAdvent.Jetpack
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] IntVariable m_coins;

        [SerializeField] FloatVariable m_speed;
        private Transform m_transform;
        
        private void Start() 
        {
            m_transform = transform;
        }
        private void FixedUpdate() 
        {
            m_transform.position = new Vector2(m_transform.position.x -m_speed.GetValue() * Time.deltaTime, m_transform.position.y);
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("Player"))
            {
                m_coins.Increment(1);
                Destroy(gameObject);
            }
        }
    }
}