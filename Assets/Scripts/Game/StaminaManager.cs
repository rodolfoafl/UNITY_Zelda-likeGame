using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZeldaTutorial.Player;

public class StaminaManager : MonoBehaviour {

    [SerializeField] Slider _staminaSlider;
    [SerializeField] PlayerMovement _player;

    void Start()
    {
        _staminaSlider.minValue = 0;
        _staminaSlider.maxValue = _player.MaxStamina;
        _staminaSlider.value = _player.MaxStamina;
    }

    public void IncreaseStamina()
    {
        _staminaSlider.value++;
        if(_staminaSlider.value > _staminaSlider.maxValue)
        {
            _staminaSlider.value = _staminaSlider.maxValue;
        }
    }

    public void DecreaseStamina()
    {
        _staminaSlider.value--;
        if (_staminaSlider.value < _staminaSlider.minValue)
        {
            _staminaSlider.value = _staminaSlider.minValue;
        }
    }
}
