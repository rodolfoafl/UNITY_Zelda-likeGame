using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour {

    [SerializeField] FloatValue _playerHealth;
    [SerializeField] Signal _healthSignal;

    public void React(int amountToIncrease)
    {
        _playerHealth.RuntimeValue += amountToIncrease;
        _healthSignal.Raise();
    }
}
