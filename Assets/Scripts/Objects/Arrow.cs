using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    [SerializeField] float _speed;

    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        _rigidbody.velocity = velocity.normalized * _speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("RoomCollider"))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RoomCollider"))
        {
            Destroy(gameObject);
        }
    }
}
