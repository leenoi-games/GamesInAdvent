using UnityEngine;
using UnityEngine.Events;

namespace GamesInAdvent.Util
{
    [CreateAssetMenu(menuName= "Variable/Int")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] int value;
        [SerializeField] int defaultValue = 0;
        private void OnEnable() 
        {
            this.hideFlags = HideFlags.DontUnloadUnusedAsset;
            value = defaultValue;
        }

        public class VariableEvent : UnityEvent {}
        private VariableEvent m_onValueChanged = new();
        
        public VariableEvent OnValueChanged
        {
            get { return m_onValueChanged; }
            set { m_onValueChanged = value; }
        }

        public IntVariable(int i)
        {
            value = i;
        }

        //public static IntVariable operator +(IntVariable a, int b) => a.SetValue(a.value + b);
        //public static IntVariable operator +=(IntVariable a, int b) => new IntVariable(a.GetValue() + b);

        public void SetValue(int f)
        {
            value = f;
            //m_onValueChanged.Invoke();
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

        
    }
}
