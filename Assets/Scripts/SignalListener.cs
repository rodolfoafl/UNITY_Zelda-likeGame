using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour {

    [SerializeField] Signal _signal;
    [SerializeField] UnityEvent _signalEvent;

    public void OnSignalRaise()
    {
        _signalEvent.Invoke();
    }

    void OnEnable()
    {
        _signal.RegisterListener(this);
    }

    void OnDisable()
    {
        _signal.UnregisterListener(this);
    }
}
