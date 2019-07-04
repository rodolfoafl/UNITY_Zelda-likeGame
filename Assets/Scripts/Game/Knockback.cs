using DG.Tweening;
using UnityEngine;
using ZeldaTutorial.Enemies;
using ZeldaTutorial.Player;

namespace ZeldaTutorial.Game{
    public class Knockback : MonoBehaviour {

        [SerializeField] float _thrust;
        [SerializeField] float _knockTime;
        [SerializeField] string _otherTag;

        Enemy _enemy;
        PlayerMovement _player;

        void OnTriggerEnter2D(Collider2D other)
        {
            _player = other.GetComponentInParent<PlayerMovement>();

            if (_otherTag != null && other.gameObject.CompareTag(_otherTag) && other.isTrigger)
            {
                Rigidbody2D otherRB = other.GetComponentInParent<Rigidbody2D>();

                if (otherRB != null)
                {
                    Vector3 difference = otherRB.transform.position - transform.position;
                    difference = difference.normalized * _thrust;
                    //otherRB.AddForce(difference, ForceMode2D.Impulse);
                    otherRB.DOMove(otherRB.transform.position + difference, _knockTime);
                    
                    
                    //ENEMY KNOCKBACK
                    if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                    {
                        _enemy = other.GetComponent<Enemy>();
                        _enemy.ChangeState(CharacterState.STAGGER);
                        _enemy.CallKnock(otherRB, _knockTime);
                        return;
                    }

                    //PLAYER KNOCKBACK
                    if (other.gameObject.CompareTag("Player"))
                    {
                        if (_player.CurrentState != CharacterState.STAGGER)
                        {
                            _player.ChangeState(CharacterState.STAGGER);
                            _player.CallKnock(otherRB, _knockTime);
                        }
                        return;
                    }                
                }
            }                                                           
        }
    }
}
