using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject {
    public float _initialValue;

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
    #endregion
}
