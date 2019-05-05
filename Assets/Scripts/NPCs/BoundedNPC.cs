using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeldaTutorial.Objects;

public class BoundedNPC : Interactable {

    [SerializeField] Collider2D _bounds;
    [SerializeField] float _moveSpeed;

    Animator _animator;
    Rigidbody2D _rigidbody;
    Transform _transform;
    Vector3 _currentDirection;

    void Start () {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        ChangeDirection();
	}
	
	void Update () {
        if (!PlayerInRange)
        {
            Move();
        }
        else
        {
            _animator.SetBool("Moving", false);
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

    void OnCollisionEnter2D(Collision2D other)
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
}
