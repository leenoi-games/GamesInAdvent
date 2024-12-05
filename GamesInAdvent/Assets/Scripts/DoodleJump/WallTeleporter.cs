using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesInAdvent.DoodleJump
{
    public class WallTeleporter : MonoBehaviour
    {
        public float m_xTeleport;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            Transform playerPos = other.transform;
            playerPos.position = new Vector3(m_xTeleport, playerPos.position.y, 0f);
        }
    }
}
