using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    bool _isActive;
    SpriteRenderer _spriteRenderer;

    [SerializeField] BoolValue _storedValue;
    [SerializeField] Sprite _activeSprite;
    [SerializeField] Door _door;

    void Start()
    {
        _isActive = _storedValue.RuntimeValue;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_isActive)
        {
            ActivateSwitch();
        }
    }

    void ActivateSwitch()
    {
        _isActive = true;
        _storedValue.RuntimeValue = _isActive;
        _door.Open();
        _spriteRenderer.sprite = _activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
