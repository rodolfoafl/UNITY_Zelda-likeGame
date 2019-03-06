using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [Header("Signals")]
	[SerializeField] Signal _powerUpSignal;

    public Signal PowerUpSignal
    {
        get
        {
            return _powerUpSignal;
        }

        set
        {
            _powerUpSignal = value;
        }
    }
}
