using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp {

    [SerializeField] FloatValue _heartContainer;
    [SerializeField] FloatValue _playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            _heartContainer.RuntimeValue += 1;
            _playerHealth.RuntimeValue = _heartContainer.RuntimeValue * 2;
            PowerUpSignal.Raise();
            Destroy(gameObject);
        }
    }
}
