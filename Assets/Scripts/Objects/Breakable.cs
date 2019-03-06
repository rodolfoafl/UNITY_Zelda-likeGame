using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZeldaTutorial.Objects{
public class Breakable : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float _deactivationTime;
    [SerializeField] bool _dropsLoots;
    [SerializeField] GameObject _loot;
   
    public void Break(Animator animator = null)
    {
        if (animator != null)
        {
            animator.SetBool("break", true);
        }
        StartCoroutine(DeactivateObject());
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_deactivationTime);
        gameObject.SetActive(false);
    }
}
}
