using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZeldaTutorial.Objects{
	
	public class TreasureChest : Interactable {

        [Header("Attributes")]
		[SerializeField] Item _content;

        [Header("DialogBox")]
        [SerializeField] GameObject _dialogBox;
        [SerializeField] Text _dialogText;

        [Header("PlayerInventory")]
        [SerializeField] Inventory _playerInventory;

        [Header("Signals")]
		[SerializeField] Signal _dropItem;


		bool _isOpen = false;
		Animator _animator;

        public Item Contents
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }
   
		void Start(){
			_animator = GetComponent<Animator>();
		}

		void Update () {
            if(Input.GetKeyDown(KeyCode.E) && PlayerInRange)
            {
				CheckChestState(_isOpen);
            }
        }
		void CheckChestState(bool isOpen){
			if(!isOpen)
			{
				if(_dialogBox != null && _dialogText != null){
					_dialogBox.SetActive(true);
					_dialogText.text = _content.ItemDescription;
				}
				_playerInventory.AddItem(_content);
				_playerInventory.CurrentItem = _content;
				_dropItem.Raise();
				_isOpen = true;
				TogglePopUp.Raise();
				_animator.SetTrigger("chestOpen");
			}
			else
			{
				if(_dialogBox != null){
					_dialogBox.SetActive(false);
				}
				_dropItem.Raise();
			}
		}

		void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger  && !_isOpen)
            {
                PlayerInRange = true;
                TogglePopUp.Raise();
            }
        }

        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger && !_isOpen)
            {
                TogglePopUp.Raise();
                PlayerInRange = false;
            }
        }
    }
}
