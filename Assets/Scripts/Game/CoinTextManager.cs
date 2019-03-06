using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour {

    [SerializeField] Inventory _playerInventory;
    [SerializeField] TextMeshProUGUI _coinText;

	public void UpdateCoinCount()
    {
        _coinText.text = "" + _playerInventory.NumberOfCoins;
    }
}
