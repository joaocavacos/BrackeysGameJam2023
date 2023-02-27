using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : Singleton<SceneManager>
{
    public bool isPaused = false;
    
    public UnityEvent OnGameOver;
    public UnityEvent OnGameRestart;

    public void GameOver()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void GameRestart()
    {
        isPaused = false;
        Time.timeScale = 1;
        OnGameRestart?.Invoke();
    }
}
