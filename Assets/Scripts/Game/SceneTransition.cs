using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    [Header("Attributes")]
	[SerializeField] string _sceneToLoad;
	[SerializeField] Vector2 _playerPosition;
    [SerializeField] float _fadeWait;

    //[SerializeField] Vector2 _cameraNewMin;
    //[SerializeField] Vector2 _cameraNewMax;

    [Header("ScriptableObjects")]
	[SerializeField] Vector2Value _playerDesiredPosition;
    //[SerializeField] Vector2Value _cameraMin;
    //[SerializeField] Vector2Value _cameraMax;

    [Header("FadePanel")]
	[SerializeField] GameObject _transitionFadePanel;

	void Awake(){
		if(_transitionFadePanel != null){
			GameObject panel = Instantiate(_transitionFadePanel, Vector3.zero, Quaternion.identity) as GameObject;
			panel.GetComponentInChildren<Animator>().SetTrigger("fadeIn");
			Destroy(panel, 1f);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") && !other.isTrigger){
			_playerDesiredPosition.InitialValue = _playerPosition;
			StartCoroutine(FadePanel());
		}
	}

	IEnumerator FadePanel(){
		if(_transitionFadePanel != null){
			GameObject panel = Instantiate(_transitionFadePanel, Vector3.zero, Quaternion.identity);
			panel.GetComponentInChildren<Animator>().SetTrigger("fadeOut");
		}
		yield return new WaitForSeconds(_fadeWait);
        //ResetCameraBounds();
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);
		while(!asyncOperation.isDone){
			yield return null;
		}
	}

    /*
    public void ResetCameraBounds()
    {
        _cameraMax.InitialValue = _cameraNewMax;
        _cameraMin.InitialValue = _cameraNewMin;
    }
    */
}
