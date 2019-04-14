using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaTutorial.Enemies
{
    
public class Log : Enemy {
    
    [Header("Attributes")]
    [SerializeField] float _chaseRadius;
    [SerializeField] float _attackRadius;

    Transform _target;
    Rigidbody2D _rigidbody;
    Animator _animator;

    #region Properties
        public Transform Target
        {
            get
            {
                return _target;
            }

            set
            {
                _target = value;
            }
        }

        public Rigidbody2D Rigidbody
        {
            get
            {
                return _rigidbody;
            }

            set
            {
                _rigidbody = value;
            }
        }

        public Animator Animator
        {
            get
            {
                return _animator;
            }

            set
            {
                _animator = value;
            }
        }

        public float ChaseRadius
        {
            get
            {
                return _chaseRadius;
            }

            set
            {
                _chaseRadius = value;
            }
        }

        public float AttackRadius
        {
            get
            {
                return _attackRadius;
            }

            set
            {
                _attackRadius = value;
            }
        }
        #endregion
    void Start()
    {
        CurrentState = CharacterState.IDLE;

        _target = GameObject.FindGameObjectWithTag("Player").transform;

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("wakeUp", true);
    }

    void FixedUpdate()
    {
        CheckTargetDistance();
    }

    public virtual void CheckTargetDistance()
    {
        if(CurrentState == CharacterState.STAGGER || CurrentState == CharacterState.ATTACK)
        {
            return;
        }

        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius && Target.gameObject.activeInHierarchy)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, MoveSpeed * Time.deltaTime);
            ChangeState(CharacterState.WALK);
            ChangeAnimation(temp - transform.position);
            _rigidbody.MovePosition(temp);
            _animator.SetBool("wakeUp", true);
        }
        else if(Vector3.Distance(_target.position, transform.position) > _chaseRadius)
        {
            _animator.SetBool("wakeUp", false);
        }
    }

    public void ChangeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    void SetAnimatorFloat(Vector2 setVector)
    {
        _animator.SetFloat("moveX", setVector.x);
        _animator.SetFloat("moveY", setVector.y);
    }
}
}
