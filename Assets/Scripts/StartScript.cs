using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    
    public static StartScript Instance;

    private bool _isGameOver = false;
    private bool _isGameStart = true;

    public GameObject endTimer;
    public GameObject timer;
    
    
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Update() {

        if (_isGameOver) {
            if (Input.GetButton("Jump")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (_isGameStart) {
            if (Input.GetButton("Jump")) {
                UnPause();
                OpenTimer();
                _isGameStart = false;
            }
        }

    }

    public void Start() {
        Pause();
    }
    public void Pause() {
        Time.timeScale = 0;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }

    public void OpenTimer() {
        timer.SetActive(true);
    }

    public void OpenEndTimer() {
        endTimer.SetActive(true);
    }

    public void GameOver() {
        Time.timeScale = 0;
        _isGameOver = true;
        OpenEndTimer();
    }

    
}
