using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ZeldaTutorial.Enemies{

public class Enemy : MonoBehaviour {

    [SerializeField] float _health;
    [SerializeField] FloatValue _maxHealth;
    [SerializeField] string _name;
    [SerializeField] int _baseAttack;
    [SerializeField] float _moveSpeed;

    SpriteRenderer _spriteRenderer;

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
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        _spriteRenderer.DOColor(Color.red, .5f).From().SetEase(Ease.InFlash);
        if(Health <= 0)
        {
            _spriteRenderer.DOFade(0f, .5f);
            Destroy(gameObject, .5f);            
        }
    }
}
}
