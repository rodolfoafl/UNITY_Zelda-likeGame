using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Item : ScriptableObject {
	[SerializeField] Sprite _itemSprite;
	[SerializeField] string _itemDescription;
	[SerializeField] bool _isKey;

	#region Properties
    public Sprite ItemSprite
    {
        get
        {
            return _itemSprite;
        }
    }

    public string ItemDescription
    {
        get
        {
            return _itemDescription;
        }
    }

    public bool IsKey
    {
        get
        {
            return _isKey;
        }
    }
	#endregion
}
