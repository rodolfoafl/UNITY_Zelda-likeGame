using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Objects;

public class BoundedNPC : Sign {

    [Header("Bounds")]
    [SerializeField] Collider2D _bounds;

    [Header("Movement")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _minMoveTime;
    [SerializeField] float _maxMoveTime;
    [SerializeField] float _minWaitTime;
    [SerializeField] float _maxWaitTime;


    float _moveTimeSeconds;
    float _waitTimeSeconds;
    bool _isMoving;
    Animator _animator;
    Rigidbody2D _rigidbody;
    Transform _transform;
    Vector3 _currentDirection;

    void Start () {
        _moveTimeSeconds = Random.Range(_minMoveTime, _maxMoveTime);
        _waitTimeSeconds = Random.Range(_minWaitTime, _maxWaitTime);

        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        ChangeDirection();
	}
	
	public override void Update () {
        base.Update();

        if (_isMoving)
        {
            _moveTimeSeconds -= Time.deltaTime;
            if(_moveTimeSeconds <= 0)
            {
                _moveTimeSeconds = Random.Range(_minMoveTime, _maxMoveTime);
                _isMoving = false;
            }

            if (!PlayerInRange)
            {
                Move();
            }
            else
            {
                _isMoving = false;
                _animator.SetBool("Moving", false);
            }
        }
        else
        {
            _waitTimeSeconds -= Time.deltaTime;
            if(_waitTimeSeconds <= 0)
            {
                if (!PlayerInRange)
                {
                    ChooseDifferentDirection();
                }
                _isMoving = true;
                _waitTimeSeconds = Random.Range(_minWaitTime, _maxWaitTime);
            }
        }
	}
    
    void Move()
    {
        _animator.SetBool("Moving", true);
        Vector3 nextDirection = _transform.position + _currentDirection * _moveSpeed * Time.deltaTime;
        if (_bounds.bounds.Contains(nextDirection)) {
            _rigidbody.MovePosition(nextDirection);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                _currentDirection = Vector3.right;
                break;
            case 1:
                _currentDirection = Vector3.up;
                break;
            case 2:
                _currentDirection = Vector3.left;
                break;
            case 3:
                _currentDirection = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        _animator.SetFloat("MoveX", _currentDirection.x);
        _animator.SetFloat("MoveY", _currentDirection.y);
    }

    private void ChooseDifferentDirection()
    {
        Vector3 direction = _currentDirection;
        ChangeDirection();
        int loops = 0;
        while (direction == _currentDirection && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }
}
