using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;


namespace GamesInAdvent.CookieClicker
{
    public class Cookie : MonoBehaviour
    {
        [SerializeField] private int m_currentCPC;
        [SerializeField] private FloatVariable m_numberOfCookies;
        public void OnClick()
        {
            m_numberOfCookies.SetValue(m_numberOfCookies.GetValue() + m_currentCPC);
        }
    }
}

