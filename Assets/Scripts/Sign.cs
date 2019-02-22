using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {
    [SerializeField] GameObject _dialogBox;
    [SerializeField] Text _dialogText;
    [SerializeField] string _dialog;
    [SerializeField] Signal _popUpOn;
    [SerializeField] Signal _popUpOff;

    bool _playerInRange;

	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            if (_dialogBox.activeInHierarchy)
            {
                _dialogBox.SetActive(false);
                _popUpOn.Raise();
            }
            else
            {
                _dialogBox.SetActive(true);
                _popUpOff.Raise();
                _dialogText.text = _dialog;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
            _popUpOn.Raise();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _popUpOff.Raise();
            _playerInRange = false;
            _dialogBox.SetActive(false);
        }
    }
}
