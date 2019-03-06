using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp {

    [Header("PlayerInventory")]
    [SerializeField] Inventory _playerInventory;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            _playerInventory.NumberOfCoins += 1;
            PowerUpSignal.Raise();
            Destroy(gameObject);
        }
    }

}
