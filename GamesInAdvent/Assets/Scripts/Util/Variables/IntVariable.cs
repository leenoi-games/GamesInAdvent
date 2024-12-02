using UnityEngine;
using UnityEngine.Events;

namespace GamesInAdvent.Util
{
    public class IntVariable : ScriptableObject
    {
        [SerializeField] int value;
        [SerializeField] int defaultValue = 0;
        public class VariableEvent : UnityEvent {}
        private VariableEvent m_OnValueChanged = new VariableEvent();
        
        public VariableEvent onValueChanged
        {
            get { return m_OnValueChanged; }
            set { m_OnValueChanged = value; }
        }

        public void SetValue(int f)
        {
            value = f;
            m_OnValueChanged.Invoke();
        }

        public int GetValue()
        {
            return this.value;
        }
        public void SetDefault()
        {
            value = defaultValue;
        }

        public void Increment(int i)
        {
            SetValue(i + value);
        }

        private void OnEnable() {
            this.hideFlags = HideFlags.DontUnloadUnusedAsset;
            value = defaultValue;
        }
    }
}
