using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Vector2Value : ScriptableObject {
	[SerializeField] Vector2 _initialValue;

	[SerializeField] Vector2 _defaultValue;

    #region Properties
    public Vector2 InitialValue
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

    public Vector2 DefaultValue
    {
        get
        {
            return _defaultValue;
        }

        set
        {
            _defaultValue = value;
        }
    }
	#endregion

}
