using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float _health;
    [SerializeField] FloatValue _maxHealth;
    [SerializeField] string _name;
    [SerializeField] int _baseAttack;
    [SerializeField] float _moveSpeed;


    CharacterState _currentState;

    #region Properties
    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public int BaseAttack
    {
        get
        {
            return _baseAttack;
        }

        set
        {
            _baseAttack = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }

        set
        {
            _moveSpeed = value;
        }
    }

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

    void Awake()
    {
        _health = _maxHealth.InitialValue;
    }

    public void ChangeState(CharacterState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
        }
    }

    //NOTE: These methods are duplicated on PlayerMovement script.
    //In the future, it would be better centralize this logic in just one place!
    public void CallKnock(Rigidbody2D knockedRB, float knockTime, float damage)
    {
        StartCoroutine(Knock(knockedRB, knockTime));
        TakeDamage(damage);
    }

    IEnumerator Knock(Rigidbody2D knockedRB, float knockTime)
    {
        if (knockedRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            knockedRB.velocity = Vector2.zero;
            CurrentState = CharacterState.IDLE;
        }
    }

    void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
