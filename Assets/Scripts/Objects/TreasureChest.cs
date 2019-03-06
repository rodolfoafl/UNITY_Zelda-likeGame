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

        [Header("ScriptableObjects")]
        [SerializeField] BoolValue _storedOpen;

        [Header("Signals")]
		[SerializeField] Signal _dropItem;


		bool _isOpen = false;
		Animator _animator;

        #region Properties
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
        #endregion

        void Start(){
			_animator = GetComponent<Animator>();
            _isOpen = _storedOpen.RuntimeValue;
            if (_isOpen)
            {
                _animator.SetTrigger("chestOpen");
            }
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
                _storedOpen.RuntimeValue = _isOpen;
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
