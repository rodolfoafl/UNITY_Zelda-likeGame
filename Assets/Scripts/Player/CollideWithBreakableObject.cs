using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Objects;

namespace ZeldaTutorial.Player
{
public class CollideWithBreakableObject : MonoBehaviour {

    Breakable _object;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            _object = other.GetComponent<Breakable>();
            if (_object != null)
            {
                _object.Break(other.GetComponent<Animator>());
                return;
            }
        }
    }
}
}
