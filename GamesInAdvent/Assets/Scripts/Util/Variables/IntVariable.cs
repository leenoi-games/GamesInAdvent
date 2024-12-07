using UnityEngine;
using UnityEngine.Events;

//namespace GamesInAdvent.Util
//{
[CreateAssetMenu(menuName= "Variable/Int")]
public class IntVariable : ScriptableObject
{
    [SerializeField] int value;
    [SerializeField] int defaultValue = 0;
    public class VariableEvent : UnityEvent {}
    private VariableEvent OnValueChanged = new VariableEvent();
    
    public VariableEvent onValueChanged
    {
        get { return OnValueChanged; }
        set { OnValueChanged = value; }
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
        OnValueChanged.Invoke();
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
//}
