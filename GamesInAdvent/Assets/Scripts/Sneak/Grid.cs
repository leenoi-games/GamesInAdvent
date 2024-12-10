using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GamesInAdvent.Snake
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] int m_gridSize;
        [SerializeField] GameObject m_tile;
        [SerializeField] List <GridTile> m_tiles;
        [SerializeField] Color m_secondaryColor;
        private float m_tileSize = 0;


        private void Start() 
        {
            m_tileSize = m_tile.transform.localScale.x;
            GenerateGrid();
            SpawnFruit();
        }

        private void GenerateGrid()
        {
            m_tiles = new List<GridTile>();
            for(int i = 0; i < m_gridSize + 2; i++)
            {
                for(int j = 0; j < m_gridSize + 2; j++)
                {
                    Vector3 tilePos = new Vector3(m_tileSize * (i + 1 - m_gridSize/2), m_tileSize * (j+1 - m_gridSize/2), 0);
                    GameObject newTile = Instantiate(m_tile, tilePos, Quaternion.identity);
                    if((i + j) % 2 == 0)
                    {
                        newTile.GetComponent<SpriteRenderer>().color = m_secondaryColor;
                    }
                    GridTile tile = newTile.GetComponent<GridTile>();
                    tile.SetTile(TileType.Empty);
                    m_tiles.Add(tile);
                    if(j == 0 || j == m_gridSize + 1|| i == 0 || i == m_gridSize + 1)
                    {
                        tile.SetTile(TileType.Danger);
                    }
                }
            }
        }

        public void UpdateSnakeTimer()
        {
            foreach(GridTile tile in m_tiles)
            {
                tile.UpdateSnakeTimer();
            }
        }

        public void SpawnFruit()
        {
            bool found = false;
            int idx = 0;
            while(!found)
            {
                int random = Random.Range(0, m_tiles.Count - 1);
                if(m_tiles[random].Type == TileType.Empty)
                {
                    found = true;
                    idx = random;
                }
            }
            Debug.Log("Found Tile");
            m_tiles[idx].SetTile(TileType.Fruit);
        }
    }
}