using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject {
    [SerializeField] float _initialValue;

    [SerializeField]
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
}
