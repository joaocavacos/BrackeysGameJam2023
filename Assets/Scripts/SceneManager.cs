using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    
    public bool isPaused = false;
    
    public UnityEvent OnGameOver;
    public UnityEvent OnGameRestart;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

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
