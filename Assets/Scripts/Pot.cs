using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    Animator _animator;

    [SerializeField] float _deactivationTime;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Break()
    {
        _animator.SetBool("break", true);
        StartCoroutine(DeactivateObject());
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_deactivationTime);
        gameObject.SetActive(false);
    }
}
