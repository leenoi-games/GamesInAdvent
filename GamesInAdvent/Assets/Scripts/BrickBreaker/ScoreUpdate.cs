using System.Collections;
using System.Collections.Generic;
using GamesInAdvent.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamesInAdvent.BrickBreaker
{
    public class ScoreUpdate : MonoBehaviour
    {
        [SerializeField] IntVariable value;
        [SerializeField] string customText;
        private TextMeshProUGUI text;

        private void Start() 
        {
            if(value != null)
            {
                value.onValueChanged.AddListener(delegate{OnValueChanged();});
            }
            text = GetComponent<TextMeshProUGUI>();
            OnValueChanged();
        }

        private void OnEnable()
        {
            text = GetComponent<TextMeshProUGUI>();
            OnValueChanged();
        }

        private void OnValueChanged()
        {
            if(customText == "")
            {
                text.text = value.GetValue().ToString();
            }
            else
            {
                text.text = value.GetValue().ToString() + customText;
            }
        }
    }
}
