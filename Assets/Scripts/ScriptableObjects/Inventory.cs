using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {
    [SerializeField] Item _currentItem;

    [SerializeField] int _numberOfKeys;
    [SerializeField] int _numberOfCoins;
    
    List<Item> _items = new List<Item>();

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
            NumberOfKeys++;
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
