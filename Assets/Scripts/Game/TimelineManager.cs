using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour {

    [SerializeField] PlayableDirector _director;
    [SerializeField] Animator _playerAnimator;

    RuntimeAnimatorController _playerRAC;

    bool fix = false;

    void OnEnable()
    {
        _playerRAC = _playerAnimator.runtimeAnimatorController;
        _playerAnimator.runtimeAnimatorController = null;
    }

    void Update()
    {
        if(_director.state != PlayState.Playing && !fix)
        {
            fix = true;
            _playerAnimator.runtimeAnimatorController = _playerRAC;
        }
    }
}
