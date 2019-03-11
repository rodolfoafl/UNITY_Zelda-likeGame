using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Enemies;
using ZeldaTutorial.Objects;

public class Room : MonoBehaviour {

    [SerializeField] Enemy[] _enemies;
    [SerializeField] Breakable[] _breakableObjects;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(_enemies, true);
            ChangeActivation(_breakableObjects, true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(_enemies, false);
            ChangeActivation(_breakableObjects, false);
        }
    }

    void ChangeActivation(Component[] components, bool activation)
    {
        if(components.Length > 0)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].gameObject.SetActive(activation);
            }
        }
    }
}
