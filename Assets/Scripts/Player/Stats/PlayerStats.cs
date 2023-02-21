using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IStats
{
    public static PlayerStats Instance;
    
    public float strengthValue = 1f;
    public float dexterityValue = 1f;
    public float intelligenceValue = 1f;
    public float vitalityValue = 1f; 
    public float agilityValue = 1f;
    
    private const float UpgradeValue = 0.2f;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        UIManager.Instance.LoadStats();
    }

    public void IncreaseStrength()
    {
        strengthValue += UpgradeValue;
        PointsManager.Instance.UsePoints(PointsManager.Instance.upgradeCostSTR);
        PointsManager.Instance.upgradeCostSTR += PointsManager.Instance.upgradeCostSTR;
    }

    public void DecreaseStrength()
    {
        strengthValue -= UpgradeValue;
        var previousValue = PointsManager.Instance.upgradeCostSTR / 2;
        PointsManager.Instance.upgradeCostSTR -= previousValue;
        PointsManager.Instance.AddTotalPoints(PointsManager.Instance.upgradeCostSTR);
    } 
    
    public void IncreaseDexterity()
    {
        dexterityValue += UpgradeValue;
        PointsManager.Instance.UsePoints(PointsManager.Instance.upgradeCostDEX);
        PointsManager.Instance.upgradeCostDEX += PointsManager.Instance.upgradeCostDEX;
    }

    public void DecreaseDexterity()
    {
        dexterityValue -= UpgradeValue;
        var previousValue = PointsManager.Instance.upgradeCostDEX / 2;
        PointsManager.Instance.upgradeCostDEX -= previousValue;
        PointsManager.Instance.AddTotalPoints(PointsManager.Instance.upgradeCostDEX);
    }

    public void IncreaseIntelligence()
    {
        intelligenceValue += UpgradeValue;
        PointsManager.Instance.UsePoints(PointsManager.Instance.upgradeCostINT);
        PointsManager.Instance.upgradeCostINT += PointsManager.Instance.upgradeCostINT;
    }

    public void DecreaseIntelligence()
    {
        intelligenceValue -= UpgradeValue;
        var previousValue = PointsManager.Instance.upgradeCostINT / 2;
        PointsManager.Instance.upgradeCostINT -= previousValue;
        PointsManager.Instance.AddTotalPoints(PointsManager.Instance.upgradeCostINT);
    }

    public void IncreaseVitality()
    {
        vitalityValue += UpgradeValue;
        PointsManager.Instance.UsePoints(PointsManager.Instance.upgradeCostVIT);
        PointsManager.Instance.upgradeCostVIT += PointsManager.Instance.upgradeCostVIT;
    }

    public void DecreaseVitality()
    {
        vitalityValue -= UpgradeValue;
        var previousValue = PointsManager.Instance.upgradeCostVIT / 2;
        PointsManager.Instance.upgradeCostVIT -= previousValue;
        PointsManager.Instance.AddTotalPoints(PointsManager.Instance.upgradeCostVIT);
    }

    public void IncreaseAgility()
    {
        agilityValue += UpgradeValue;
        PointsManager.Instance.UsePoints(PointsManager.Instance.upgradeCostAGL);
        PointsManager.Instance.upgradeCostAGL += PointsManager.Instance.upgradeCostAGL;
    }

    public void DecreaseAgility()
    {
        agilityValue -= UpgradeValue;
        var previousValue = PointsManager.Instance.upgradeCostAGL / 2;
        PointsManager.Instance.upgradeCostAGL -= previousValue;
        PointsManager.Instance.AddTotalPoints(PointsManager.Instance.upgradeCostAGL);
    }
}
