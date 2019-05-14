using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZeldaTutorial.Player
{
    public class HeartManager : MonoBehaviour {

        [Header("Sprites")]
        [SerializeField] Image[] _hearts;
        [SerializeField] Sprite _fullHeart;
        [SerializeField] Sprite _halfHeart;
        [SerializeField] Sprite _emptyHeart;

        [Header("ScriptableObjects")]
        [SerializeField] FloatValue _heartsContainers;
        [SerializeField] FloatValue _playerCurrentHealth;

        void Start()
        {
            InitializeHearts();
        }

        public void InitializeHearts()
        {
            for(int i = 0; i < _heartsContainers.RuntimeValue; i++)
            {
                if (i < _hearts.Length)
                {
                    _hearts[i].gameObject.SetActive(true);
                    _hearts[i].sprite = _fullHeart;
                }
            }
        }

        public void UpdateHearts()
        {
            InitializeHearts();
            float tempHealth = _playerCurrentHealth.RuntimeValue / 2;
            for (int i = 0; i < _heartsContainers.RuntimeValue; i++)
            {
                if(i <= tempHealth - 1)
                {
                    _hearts[i].sprite = _fullHeart;
                }
                else if(i >= tempHealth)
                {
                    _hearts[i].sprite = _emptyHeart;
                }
                else
                {
                    _hearts[i].sprite = _halfHeart;
                }
            }
        }
    }
}
