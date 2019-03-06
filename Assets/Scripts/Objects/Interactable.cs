using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaTutorial.Objects{
	public class Interactable : MonoBehaviour {

        [Header("Signals")]
	    [SerializeField] Signal _togglePopUp;

	    bool _playerInRange;

		#region Properties
        public bool PlayerInRange
        {
            get
            {
                return _playerInRange;
            }

            set
            {
                _playerInRange = value;
            }
        }

        public Signal TogglePopUp
        {
            get
            {
                return _togglePopUp;
            }

            set
            {
                _togglePopUp = value;
            }
        }
		#endregion
    
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                PlayerInRange = true;
                TogglePopUp.Raise();
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                TogglePopUp.Raise();
                PlayerInRange = false;
            }
        }
	}
}
