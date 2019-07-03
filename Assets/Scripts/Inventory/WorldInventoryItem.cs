using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInventoryItem : MonoBehaviour {

    [SerializeField] PlayerInventory _playerInventory;
    [SerializeField] InventoryItem _inventoryItem;

    void AddItemToInventory()
    {
        if(_playerInventory && _inventoryItem)
        {
            if (!_playerInventory.Inventory.Contains(_inventoryItem))
            {

                _playerInventory.Inventory.Add(_inventoryItem);
            }
            _inventoryItem.NumberHeld++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemToInventory();
            Destroy(gameObject);
        }
    }
}
