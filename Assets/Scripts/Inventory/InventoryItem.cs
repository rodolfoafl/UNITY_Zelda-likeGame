using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem: ScriptableObject {

    [SerializeField] string _itemName;
    [SerializeField] string _itemDescription;

    [SerializeField] Sprite _itemImage;

    [SerializeField] int _numberHeld;

    [SerializeField] bool _usable;
    [SerializeField] bool _unique;

    #region Properties
    public string ItemName
    {
        get
        {
            return _itemName;
        }

        protected set
        {
            _itemName = value;
        }
    }

    public string ItemDescription
    {
        get
        {
            return _itemDescription;
        }

        protected set
        {
            _itemDescription = value;
        }
    }

    public Sprite ItemImage
    {
        get
        {
            return _itemImage;
        }

        protected set
        {
            _itemImage = value;
        }
    }

    public int NumberHeld
    {
        get
        {
            return _numberHeld;
        }

        protected set
        {
            _numberHeld = value;
        }
    }

    public bool Usable
    {
        get
        {
            return _usable;
        }

        protected set
        {
            _usable = value;
        }
    }

    public bool Unique
    {
        get
        {
            return _unique;
        }

        protected set
        {
            _unique = value;
        }
    }
    #endregion
}
