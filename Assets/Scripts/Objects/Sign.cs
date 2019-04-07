using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZeldaTutorial.Objects
{
    public class Sign : Interactable {

        [Header("DialogBox")]
        [SerializeField] GameObject _dialogBox;
        [SerializeField] Text _dialogText;
        [SerializeField] string _dialog;

        void Update () {
            if(Input.GetButtonDown("Attack") && PlayerInRange)
            {
                if (_dialogBox.activeInHierarchy)
                {
                    _dialogBox.SetActive(false);
                    TogglePopUp.Raise();
                }
                else
                {
                    _dialogBox.SetActive(true);
                    TogglePopUp.Raise();
                    _dialogText.text = _dialog;
                }
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                TogglePopUp.Raise();
                PlayerInRange = false;
                _dialogBox.SetActive(false);
            }
        }
    }
}
