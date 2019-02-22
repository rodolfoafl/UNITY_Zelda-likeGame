using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPopUp : MonoBehaviour {

	[SerializeField] GameObject _popUp;

	public void Enable(){
		_popUp.SetActive(true);
	}

	public void Disable(){
		_popUp.SetActive(false);
	}
}
