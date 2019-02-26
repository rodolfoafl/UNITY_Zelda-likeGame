using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaTutorial.Player
{
public class PlayerMovement : MonoBehaviour {

    [SerializeField] float _speed;
    [SerializeField] FloatValue _currentHealth;
    [SerializeField] Signal _playerHealthSignal;
    [SerializeField] Vector2Value _transitionStartingPosition;
    [SerializeField] Inventory _inventory;
    [SerializeField] SpriteRenderer _collectedItemSprite;

    Rigidbody2D _rigidbody;

    Vector3 _change;

    Animator _animator;

    CharacterState _currentState;

    #region Properties
    public CharacterState CurrentState
    {
        get
        {
            return _currentState;
        }

        protected set
        {
            _currentState = value;
        }
    }
    #endregion

	void Start () {
        _currentState = CharacterState.WALK;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("moveX", 0);
        _animator.SetFloat("moveY", -1);
        transform.position = _transitionStartingPosition.InitialValue;
    }
	
	void Update () {
        if(CurrentState == CharacterState.INTERACT)
        {
            return;
        }

        _change = Vector2.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Attack") && _currentState != CharacterState.ATTACK && _currentState != CharacterState.STAGGER)
        {
            StartCoroutine(Attack());
        }
        else if (_currentState == CharacterState.WALK || _currentState == CharacterState.IDLE)
        {
            UpdateAnimationAndMove();
        }
	}

    public void ChangeState(CharacterState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
        }
    }

    IEnumerator Attack()
    {
        _animator.SetBool("attacking", true);
        _currentState = CharacterState.ATTACK;
        yield return null;
        _animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
        if(CurrentState != CharacterState.INTERACT)
        {
            ChangeState(CharacterState.WALK);
        }
    }

    public void CollectItem()
    {
        if(_inventory.CurrentItem != null){
            if(CurrentState != CharacterState.INTERACT)
            {
                _animator.SetBool("getItem", true);
                ChangeState(CharacterState.INTERACT);
                _collectedItemSprite.sprite = _inventory.CurrentItem.ItemSprite;
            }
            else
            {
                _animator.SetBool("getItem", false);
                ChangeState(CharacterState.IDLE);
                _collectedItemSprite.sprite = null;
                _inventory.CurrentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            MoveCharacter();
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        _rigidbody.MovePosition(transform.position + _change.normalized * _speed * Time.deltaTime);
        _animator.SetFloat("moveX", _change.x);
        _animator.SetFloat("moveY", _change.y);
        _animator.SetBool("moving", true);
    }


    //NOTE: These methods are duplicated on Enemy script.
    //In the future, it would be better to centralize this logic in just one place!
    public void CallKnock(Rigidbody2D knockedRB, float knockTime, float damage)
    {
        _currentHealth.RuntimeValue -= damage;
        _playerHealthSignal.Raise();
        if (_currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(Knock(knockedRB, knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Knock(Rigidbody2D knockedRB, float knockTime)
    {
        if (knockedRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            knockedRB.velocity = Vector2.zero;
            _currentState = CharacterState.IDLE;
        }
    }
}
}
