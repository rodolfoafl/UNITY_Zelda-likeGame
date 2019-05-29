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

    void Start()
    {
        MakeInventorySlots();
        SetDescriptionAndButton("", false);
    }

    void MakeInventorySlots()
    {
        if (_playerInventory)
        {
            for (int i = 0; i < _playerInventory.Inventory.Count; i++)
            {
                GameObject newGOSlot = Instantiate(_blankInventorySlot, _inventoryContent.transform);

                InventorySlot newSlot = newGOSlot.GetComponent<InventorySlot>();
                newSlot.Setup(_playerInventory.Inventory[i], this);
            }
        }
    }

    public void SetDescriptionAndButton(string description, bool buttonActive)
    {
        _descriptionText.text = description;
        _useButton.SetActive(buttonActive);
    }
}
