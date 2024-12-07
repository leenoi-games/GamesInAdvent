using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamesInAdvent.Frogger
{
    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] GameObject m_car;
        [SerializeField] float m_startCooldown;
        [SerializeField] private float m_cooldown;
        private float m_carTimer;
        private bool m_hasStarted;
        private float m_startCounter;
        private void Start() 
        {
            m_hasStarted = false;
            m_startCounter = 0;
        }

        private void Update()
        {
            
            if(m_hasStarted == false)
            {
                m_startCounter += Time.deltaTime;
                if(m_startCounter > m_startCooldown) m_hasStarted = true;
                return;
            }
            m_carTimer += Time.deltaTime;
            if(m_carTimer > m_cooldown && m_hasStarted ==true)
            {
                m_carTimer = 0;
                Instantiate(m_car, transform.position, Quaternion.identity);
            }
        }
    }
}