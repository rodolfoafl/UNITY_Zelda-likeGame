using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    [SerializeField] GameObject _playerActionPopup;
    [SerializeField] GameObject _dialogBox;

    [SerializeField] Text _dialogText;

    [SerializeField] string _dialog;

    bool _playerInRange;

	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            if (_dialogBox.activeInHierarchy)
            {
                _dialogBox.SetActive(false);
                _playerActionPopup.SetActive(true);
            }
            else
            {
                _dialogBox.SetActive(true);
                _playerActionPopup.SetActive(false);
                _dialogText.text = _dialog;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
            _playerActionPopup.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
            _playerActionPopup.SetActive(false);
            _dialogBox.SetActive(false);
        }
    }
}
