using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	[SerializeField] string _sceneToLoad;
	[SerializeField] Vector2 _playerPosition;
	[SerializeField] Vector2Value _playerDesiredPosition;
	[SerializeField] GameObject _transitionFadePanel;
	[SerializeField] float _fadeWait;

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
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);
		while(!asyncOperation.isDone){
			yield return null;
		}
	}
}
