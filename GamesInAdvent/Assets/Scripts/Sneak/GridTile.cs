using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.Snake
{
    public class GridTile : MonoBehaviour
    {
        [SerializeField] float m_sneakTimer;
        [SerializeField] TileType m_tileType;
        [SerializeField] Color m_snakecolor;
        [SerializeField] Color m_fruitColor;
        [SerializeField] PlayerMovement m_playerMovement;
        public TileType Type{get => m_tileType;}
        private Color m_baseColor;
        private SpriteRenderer m_spriteRenderer;
        private float m_nextUpdate;

        private void OnEnable() 
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_baseColor = m_spriteRenderer.color;
        }

        public void SetTile(TileType tileType)
        {
            m_tileType = tileType;
            if(m_tileType == TileType.Fruit)
            {
                m_baseColor = m_spriteRenderer.color;
                m_spriteRenderer.color = m_fruitColor;
            }
            else if (m_tileType == TileType.Danger)
            {
                m_spriteRenderer.color = Color.black;
            }
        }

        public void UpdateSnakeTimer()
        {
            if(m_tileType == TileType.Snake)
            {
                m_sneakTimer++;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if(m_tileType == TileType.Danger || m_tileType == TileType.Snake)
                {
                    m_playerMovement.Lose();
                    return;
                }
                if(m_tileType == TileType.Fruit)
                {
                    Debug.Log("Eating Fruit");
                    m_playerMovement.Grow();
                    m_tileType = TileType.Empty;
                    m_spriteRenderer.color = m_baseColor;
                }
                m_tileType = TileType.Snake;
                m_baseColor = m_spriteRenderer.color;
                m_spriteRenderer.color = m_snakecolor;
                m_sneakTimer = m_playerMovement.Size;
            }
        }



        private void FixedUpdate() 
        {
            if(Time.time < m_nextUpdate) return;

            m_sneakTimer -= 1;

            if(m_sneakTimer == 0)
            {
                m_tileType = TileType.Empty;
                m_spriteRenderer.color = m_baseColor;
            }
            m_nextUpdate = Time.time + (1f/m_playerMovement.Speed);
        }
    }

    public enum TileType
    {
        Snake,
        Empty,
        Fruit,
        Danger
    };
}