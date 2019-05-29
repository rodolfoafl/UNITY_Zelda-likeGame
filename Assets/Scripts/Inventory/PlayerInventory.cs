using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField] List<InventoryItem> _playerInventory = new List<InventoryItem>();

    #region Properties
    public List<InventoryItem> Inventory
    {
        get
        {
            return _playerInventory;
        }

        protected set
        {
            _playerInventory = value;
        }
    }
    #endregion
}
