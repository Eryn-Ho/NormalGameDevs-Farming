using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenManager : MonoBehaviour
{ 
    [SerializeField] private GameObject _gamePausedUI;
    private GameObject _player;
    private bool _isPaused = false;
    private bool _canPause;

    private void Awake()
    {
        //makes sure game isn't paused when it starts up, turns off the UI game objects, adds event listeners
        _isPaused = false;
        _canPause = true;
        _player = FindObjectOfType<PlayerController>().gameObject;
        UnPauseTime();
    }

    private void Update()
    //would like to refactor these into events
    //debug purposes only
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }
    public void ShowPauseMenu()
    {
        if (_canPause)
        {
            _isPaused = !_isPaused;
            if (_isPaused == true)
            {
                PauseTime();
                _gamePausedUI.SetActive(true);
            }
            else if (_isPaused == false)
            {
                UnPauseTime();
                _gamePausedUI.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }
    public void ResumeGame()
    {
        ShowPauseMenu();
    }
    public static void PauseTime()
    {
        Time.timeScale = 0;
        Debug.Log("Stopping time");
    }

    public static void UnPauseTime()
    {
        Time.timeScale = 1;
        Debug.Log("Resuming time");
    }
}

