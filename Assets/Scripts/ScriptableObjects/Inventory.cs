using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {
    [SerializeField] Item _currentItem;
    List<Item> _items = new List<Item>();
    public int _numberOfKeys;
    public int _numberOfCoins;

    #region Properties
    public Item CurrentItem
    {
        get
        {
            return _currentItem;
        }

        set
        {
            _currentItem = value;
        }
    }

    public List<Item> Items
    {
        get
        {
            return _items;
        }

        set
        {
            _items = value;
        }
    }

    public int NumberOfKeys
    {
        get
        {
            return _numberOfKeys;
        }

        set
        {
            _numberOfKeys = value;
        }
    }

    public int NumberOfCoins
    {
        get
        {
            return _numberOfCoins;
        }

        set
        {
            _numberOfCoins = value;
        }
    }
    #endregion

    public void AddItem(Item itemToAdd){
        if(itemToAdd.IsKey)
        {
            _numberOfKeys ++;
        }
        else
        {
            if(!_items.Contains(itemToAdd))
            {
                _items.Add(itemToAdd);
            }
        }
    }
}
