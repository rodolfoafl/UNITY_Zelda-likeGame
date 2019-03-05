using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp {

	[SerializeField] FloatValue _playerHealth;
	[SerializeField] float _amountToIncrease;
	[SerializeField] FloatValue _heartContainers;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") && !other.isTrigger)
		{
			_playerHealth.RuntimeValue += _amountToIncrease;
			if(_playerHealth.InitialValue > _heartContainers.RuntimeValue * 2)
			{
				_playerHealth.InitialValue = _heartContainers.RuntimeValue * 2;
			}
			PowerUpSignal.Raise();
			Destroy(gameObject);
		}
	}
}
