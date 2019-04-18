using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject {

    List<SignalListener> _listeners = new List<SignalListener>();

    public void Raise()
    {
        for(int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnSignalRaise();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(SignalListener listener)
    {
        _listeners.Remove(listener);
    }
}
