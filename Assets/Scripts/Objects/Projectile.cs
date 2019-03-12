using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[Header("Attributes")]
	[SerializeField] float _speed;
	[SerializeField] float _lifetime;

	Vector2 _directionToMove;
	Rigidbody2D _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		_lifetime -= Time.deltaTime;
		if(_lifetime <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void Launch(Vector2 initialVelocity)
	{
		_rigidbody.velocity = initialVelocity * _speed;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") && !other.isTrigger){
			Destroy(gameObject);
		}
	}
}
