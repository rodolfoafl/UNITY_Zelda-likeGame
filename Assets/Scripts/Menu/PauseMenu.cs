using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject _pausePanel;
    [SerializeField] string _mainMenu;

    bool _isPaused;
        
    void Start()
    {
        _isPaused = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain()
    {
        //TODO: Add a confirmation prompt before actually quitting!
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenu);
    }
}
