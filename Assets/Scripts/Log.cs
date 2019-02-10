using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy {

    Transform _target;
    Rigidbody2D _rigidbody; 

    [SerializeField] float _chaseRadius;
    [SerializeField] float _attackRadius;
    [SerializeField] Transform _homePosition;

    void Start()
    {
        CurrentState = EnemyState.IDLE;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(CurrentState == EnemyState.STAGGER || CurrentState == EnemyState.ATTACK)
        {
            return;
        }

        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
           Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, MoveSpeed * Time.deltaTime);
            ChangeState(EnemyState.WALK);
            _rigidbody.MovePosition(temp);
        } 
    }

    void ChangeState(EnemyState newState)
    {
        if(CurrentState != newState)
        {
            CurrentState = newState;
        }
    }
}
