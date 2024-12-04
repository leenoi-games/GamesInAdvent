using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using UnityEngine;

public class CookieManager : MonoBehaviour
{
    [SerializeField] private FloatVariable m_numberOfCookies;
    [SerializeField] private FloatVariable m_cps;

    private void Update() 
    {
        if(m_cps.GetValue() != 0)
        {
            m_numberOfCookies.SetValue(m_numberOfCookies.GetValue() + m_cps.GetValue() * Time.deltaTime); 
        }
        
    }
}
