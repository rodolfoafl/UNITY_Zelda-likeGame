using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] Transform _target;

    [SerializeField] float _smoothing;

    [SerializeField] Vector2 _maxPosition;
    [SerializeField] Vector2 _minPosition;

    #region Properties
    public Vector2 MaxPosition
    {
        get
        {
            return _maxPosition;
        }

        set
        {
            _maxPosition = value;
        }
    }

    public Vector2 MinPosition
    {
        get
        {
            return _minPosition;
        }

        set
        {
            _minPosition = value;
        }
    }
    #endregion

    void LateUpdate()
    {
        if(transform.position != _target.position)
        {
            Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, _minPosition.x, _maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _minPosition.y, _maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing);
        }
    }
}
