using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject m_collider;
    private bool m_colliederState = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if( other.gameObject.transform.position.y >= transform.position.y)
                m_collider.SetActive(true);
            else
                m_collider.SetActive(false);
        }
    }
}
