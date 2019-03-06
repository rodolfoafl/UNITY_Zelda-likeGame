using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver {

    public bool _initialValue;

    bool _runtimeValue;

    #region Properties
    public bool InitialValue
    {
        get
        {
            return _initialValue;
        }

        set
        {
            _initialValue = value;
        }
    }

    public bool RuntimeValue
    {
        get
        {
            return _runtimeValue;
        }

        set
        {
            _runtimeValue = value;
        }
    }
    #endregion

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
