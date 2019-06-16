using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] GameObject _blankInventorySlot;
    [Tooltip("This should be the Content object, inside your ScrollView's Viewport")]
    [SerializeField] GameObject _inventoryContent;
    [SerializeField] GameObject _useButton;

    [SerializeField] TextMeshProUGUI _descriptionText;

    [SerializeField] PlayerInventory _playerInventory;

    public InventoryItem CurrentItem { get; protected set; }

    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetDescriptionAndButton("", false, null);
    }

    void MakeInventorySlots()
    {
        if (_playerInventory)
        {
            for (int i = 0; i < _playerInventory.Inventory.Count; i++)
            {
                if (_playerInventory.Inventory[i].NumberHeld > 0) { 

                    GameObject newGOSlot = Instantiate(_blankInventorySlot, _inventoryContent.transform);

                    InventorySlot newSlot = newGOSlot.GetComponent<InventorySlot>();
                    newSlot.Setup(_playerInventory.Inventory[i], this);
                }
            }
        }
    }

    public void SetDescriptionAndButton(string description, bool buttonActive, InventoryItem newItem)
    {
        CurrentItem = newItem;
        _descriptionText.text = description;
        _useButton.SetActive(buttonActive);
    }

    void ClearInventorySlots()
    {
        for (int i = 0; i < _inventoryContent.transform.childCount; i++)
        {
            Destroy(_inventoryContent.transform.GetChild(i).gameObject);
        }
    }

    public void UseItem()
    {
        if (CurrentItem)
        {
            CurrentItem.CallEvent();
            ClearInventorySlots();
            MakeInventorySlots();

            if (CurrentItem.NumberHeld == 0)
            {
                SetDescriptionAndButton("", false, null);
            }
        }
    }
}
