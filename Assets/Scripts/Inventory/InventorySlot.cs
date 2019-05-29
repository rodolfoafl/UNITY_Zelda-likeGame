using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _itemNumberText;

    [SerializeField] Image _itemImage;

    InventoryItem _inventoryItem;

    InventoryManager _inventoryManager;

    #region Properties
    public InventoryItem InventoryItem
    {
        get
        {
            return _inventoryItem;
        }

        set
        {
            _inventoryItem = value;
        }
    }

    public InventoryManager InventoryManager
    {
        get
        {
            return _inventoryManager;
        }

        set
        {
            _inventoryManager = value;
        }
    }
    #endregion

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        _inventoryItem = newItem;
        _inventoryManager = newManager;

        if (_inventoryItem)
        {
            _itemImage.sprite = _inventoryItem.ItemImage;
            _itemNumberText.text = _inventoryItem.NumberHeld.ToString();
        }
    }
}
