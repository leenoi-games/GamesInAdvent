using UnityEngine;
using UnityEngine.Events;

namespace GamesInAdvent.Util
{
    [CreateAssetMenu(menuName= "Variable/String")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] string value;
        [SerializeField] string defaultValue = "";
        public class VariableEvent : UnityEvent {}
        private VariableEvent m_OnValueChanged = new VariableEvent();
        
        public VariableEvent onValueChanged
        {
            get { return m_OnValueChanged; }
            set { m_OnValueChanged = value; }
        }

        public void SetValue(string str)
        {
            value = str;
            m_OnValueChanged.Invoke();
        }

        public string GetValue()
        {
            return this.value;
        }

        public void SetDefault()
        {
            value = defaultValue;
        }

        private void OnEnable() {
            this.hideFlags = HideFlags.DontUnloadUnusedAsset;
            SetDefault();
        }
    }
}

