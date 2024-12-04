using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace GamesInAdvent.CookieClicker
{
    public class CookieCounterText : MonoBehaviour
    {
        [SerializeField] FloatVariable m_numOfCookies;
        [SerializeField] string m_customText;
        private TextMeshProUGUI m_text;

        private void OnEnable()
        {
            m_text = GetComponent<TextMeshProUGUI>();
        }
        private void Update() 
        {
            if(m_customText == "")
            {
                int cookies = (int)m_numOfCookies.GetValue();
                m_text.text = cookies.ToString();
            }
            else
            {
                int cookies = (int)m_numOfCookies.GetValue();
                m_text.text = cookies.ToString() + m_customText;
            }
        }
    }
}

