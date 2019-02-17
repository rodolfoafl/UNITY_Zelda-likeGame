using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RoomMove : MonoBehaviour {

    [SerializeField] Vector2 _cameraChange;

    [SerializeField] Vector3 _playerChange;

    [SerializeField] bool _needText;
    [SerializeField] string _placeName;
    [SerializeField] GameObject _text;
    [SerializeField] Text _placeText;

    [SerializeField] float _placeTextDuration;

    CameraMovement _camera;

    void Start()
    {
        _camera = Camera.main.GetComponent<CameraMovement>();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            _camera.MinPosition += _cameraChange;
            _camera.MaxPosition += _cameraChange;
            other.transform.position += _playerChange;

            if (_needText)
            {
                StartCoroutine(PlaceName());
            }
        }
    }

    IEnumerator PlaceName()
    {
        _text.SetActive(true);
        _placeText.text = _placeName;
        _placeText.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(_placeTextDuration);
        _placeText.DOFade(0f, 0.5f);
        yield return new WaitForSeconds(_placeTextDuration);
        _text.SetActive(false);
    }
}
