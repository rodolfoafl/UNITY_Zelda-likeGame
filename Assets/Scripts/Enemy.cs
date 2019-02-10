using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IDLE,
    WALK,
    ATTACK,
    STAGGER
}

public class Enemy : MonoBehaviour {

    [SerializeField] int _health;
    [SerializeField] string _name;
    [SerializeField] int _baseAttack;
    [SerializeField] float _moveSpeed;

    EnemyState _currentState;

    #region Properties
    public int Health
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

    public EnemyState CurrentState
    {
        get
        {
            return _currentState;
        }

        set
        {
            _currentState = value;
        }
    }
    #endregion

    public void CallKnock(Rigidbody2D knockedRB, float knockTime)
    {
        StartCoroutine(Knock(knockedRB, knockTime));
    }

    IEnumerator Knock(Rigidbody2D knockedRB, float knockTime)
    {
        if (knockedRB != null)
        {
            Debug.Log("enemy knocked!");
            yield return new WaitForSeconds(knockTime);
            knockedRB.velocity = Vector2.zero;
            CurrentState = EnemyState.IDLE;
        }
    }
}
