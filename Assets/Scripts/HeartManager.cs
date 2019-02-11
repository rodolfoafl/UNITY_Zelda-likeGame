using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour {

    [SerializeField] Image[] _hearts;
    [SerializeField] Sprite _fullHeart;
    [SerializeField] Sprite _halfHeart;
    [SerializeField] Sprite _emptyHeart;
    [SerializeField] FloatValue _heartsContainers;

    void Start()
    {
        InitializeHearts();
    }

    public void InitializeHearts()
    {
        for(int i = 0; i < _heartsContainers.InitialValue; i++)
        {
            _hearts[i].gameObject.SetActive(true);
            _hearts[i].sprite = _fullHeart;
        }
    }
}
