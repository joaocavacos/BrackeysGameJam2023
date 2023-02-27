using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : PersistentSingleton<PointsManager>
{
    public float totalPoints;
    [SerializeField] private float timePoints;
    [SerializeField] private float killPoints;
    [SerializeField] private int killCountRun;

    public float upgradeCostSTR;
    public float upgradeCostAGL;
    public float upgradeCostVIT;
    public float upgradeCostINT;
    public float upgradeCostDEX;

    private int hourCount;
    private int minuteCount;
    private float secondsCount;
    
    private void Start()
    {
        UIManager.Instance.UpdatePoints();
    }

    void Update()
    {
        if(!SceneManager.Instance.isPaused) CalculateTimeElapsed();
    }

    public void AddTotalPoints(float value) => totalPoints += value;

    public void IncreaseKillPoints(int value)
    {
        killPoints += value;
        killCountRun++;
    }

    public void UsePoints(float value) => totalPoints -= value;

    public void EndGamePoints()
    {
        var timeString = $"{hourCount:00}:{minuteCount:00}:{secondsCount:00}";

        UIManager.Instance.timeElapsedText.text = "Time: " + timeString;
        UIManager.Instance.killCountText.text = "Kills: " + killCountRun; 
        UIManager.Instance.currentRunPointsText.text = "Points in the run: " + FinalPointsRun();
        AddTotalPoints(FinalPointsRun());
        UIManager.Instance.UpdatePoints();
    }

    public float GetCurrentPoints()
    {
        return Mathf.RoundToInt(totalPoints);
    }

    private float FinalPointsRun()
    {
        return killPoints + Mathf.RoundToInt(timePoints);
    }

    private void CalculateTimeElapsed()
    {
        secondsCount += Time.deltaTime;
        timePoints += 2 * Time.deltaTime;

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if(minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        } 
    }

    public void ResetRunStats()
    {
        secondsCount = 0;
        minuteCount = 0;
        hourCount = 0;
        killCountRun = 0;
        killPoints = 0;
        timePoints = 0;
    }
}
