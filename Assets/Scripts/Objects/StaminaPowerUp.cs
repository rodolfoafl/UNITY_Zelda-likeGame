using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPowerUp : PowerUp {

    bool _enabled = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_enabled)
        {
            enabled = true;
            PowerUpSignal.Raise();
            Destroy(gameObject);
        }
    }
}
