using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    [SerializeField] float _thrust;
    [SerializeField] float _knockTime;

    Enemy _enemy;
    PlayerMovement _player;

    void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<PlayerMovement>();

        if (other.gameObject.CompareTag("Breakable") && gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<Pot>() != null)
            {
                other.GetComponent<Pot>().Break();
                return;
            }
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D otherRB = other.GetComponent<Rigidbody2D>();

            if (otherRB != null)
            {
                Vector2 difference = otherRB.transform.position - transform.position;
                difference = difference.normalized * _thrust;
                otherRB.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("trigger Enemy!");
                    _enemy = other.GetComponent<Enemy>();
                    _enemy.CurrentState = EnemyState.STAGGER;
                    _enemy.CallKnock(otherRB, _knockTime);
                    return;
                }

                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("trigger Player!");
                    _player.CurrentState = PlayerState.STAGGER;
                    _player.CallKnock(otherRB, _knockTime);
                    return;
                }                
            }
        }
    }
}
