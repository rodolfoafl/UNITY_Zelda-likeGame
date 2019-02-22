using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaTutorial.Player
{

public class ActionPopUp : MonoBehaviour {

	[SerializeField] GameObject _popUp;
	bool _isActive = false;

	public void ToggleActive(){
		_isActive = !_isActive;
		_popUp.SetActive(_isActive);
	}
}
}
