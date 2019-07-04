using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace ZeldaTutorial.Enemies{

    public class Enemy : MonoBehaviour {

        [Header("Attributes")]
        [SerializeField] float _health;
        [SerializeField] string _name;
        [SerializeField] int _baseAttack;
        [SerializeField] float _moveSpeed;
        [SerializeField] Transform _homePosition;

        [Header("LootTables")]
        [SerializeField] LootTable _loot;

        [Header("ScriptableObjects")]
        [SerializeField] FloatValue _maxHealth;

        [Header("Effects")]
        [SerializeField] GameObject _deathEffect;

        [Header("Signals")]
        [SerializeField] Signal _enemyRoomCleared;

        SpriteRenderer _spriteRenderer;
        float _deathEffectDelay = 1f;

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

        void OnEnable()
        {
            if (_homePosition != null)
            {
                transform.position = _homePosition.position;
            }

            _health = _maxHealth.InitialValue;
            _currentState = CharacterState.IDLE;
        }

        public void ChangeState(CharacterState newState)
        {
            if (CurrentState != newState)
            {
                CurrentState = newState;
            }
        }

        void DeathEffect()
        {
            if(_deathEffect != null)
            {
                GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, _deathEffectDelay);
            }
        }

        void MakeLoot()
        {
            if(_loot != null)
            {
                PowerUp current = _loot.LootPowerUp();
                if(current != null)
                {
                    Instantiate(current.gameObject, transform.position, Quaternion.identity);
                }
            }
        }

        //NOTE: These methods are duplicated on PlayerMovement script.
        //In the future, it would be better centralize this logic in just one place!
        public void CallKnock(Rigidbody2D knockedRB, float knockTime)
        {
            StartCoroutine(Knock(knockedRB, knockTime));
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
                //_spriteRenderer.DOFade(0f, .5f);
                Health = 0;
                DeathEffect();
                MakeLoot();
                gameObject.SetActive(false);
                if (_enemyRoomCleared != null)
                {
                    _enemyRoomCleared.Raise();
                    Debug.Log("Room Cleared!");
                }
                //Destroy(gameObject);            
            }
        }
    }
}
