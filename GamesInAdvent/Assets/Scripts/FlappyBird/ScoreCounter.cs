using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private IntVariable m_score;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            m_score.SetValue(m_score.GetValue() + 1);
        }
    }
}
