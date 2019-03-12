using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Enemies;
using ZeldaTutorial.Objects;

public class Room : MonoBehaviour {

    [SerializeField] Enemy[] _enemies;
    [SerializeField] Breakable[] _breakableObjects;
    [SerializeField] GameObject _virtualCamera;

    #region Properties
    public Enemy[] Enemies
    {
        get
        {
            return _enemies;
        }

        set
        {
            _enemies = value;
        }
    }

    public GameObject VirtualCamera
    {
        get
        {
            return _virtualCamera;
        }

        set
        {
            _virtualCamera = value;
        }
    }
    #endregion
    
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(_enemies, true);
            ChangeActivation(_breakableObjects, true);
            _virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeActivation(_enemies, false);
            ChangeActivation(_breakableObjects, false);
            _virtualCamera.SetActive(false);
        }
    }

    public void ChangeActivation(Component[] components, bool activation)
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
