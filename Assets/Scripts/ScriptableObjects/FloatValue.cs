using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver {
    public float _initialValue;

    [HideInInspector]
    float _runtimeValue;

    #region Properties
    public float InitialValue
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

    public float RuntimeValue
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
