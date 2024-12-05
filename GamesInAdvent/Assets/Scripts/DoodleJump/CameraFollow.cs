using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace GamesInAdvent.DoodleJump
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform m_playerPos;
        private void FixedUpdate() 
        {
            this.transform.position = new Vector3(transform.position.x, Math.Max(m_playerPos.position.y, transform.position.y), -10);
        }
    }
}
