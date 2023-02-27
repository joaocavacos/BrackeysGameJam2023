using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text agilityText;
    [SerializeField] private TMP_Text strengthText;
    [SerializeField] private TMP_Text dexterityText;
    [SerializeField] private TMP_Text intelligenceText;
    [SerializeField] private TMP_Text vitalityText;

    [SerializeField] private Button decreaseAGL;
    [SerializeField] private Button increaseAGL;
    [SerializeField] private Button decreaseSTR;
    [SerializeField] private Button increaseSTR;
    [SerializeField] private Button decreaseDEX;
    [SerializeField] private Button increaseDEX;
    [SerializeField] private Button decreaseVIT;
    [SerializeField] private Button increaseVIT;
    [SerializeField] private Button decreaseINT;
    [SerializeField] private Button increaseINT;
    
    [SerializeField] private TMP_Text totalPointsText;
    public TMP_Text timeElapsedText;
    public TMP_Text killCountText;
    public TMP_Text currentRunPointsText;

    void Start()
    {
        agilityText.text = PlayerStats.Instance.agilityValue.ToString(CultureInfo.InvariantCulture);
        strengthText.text = PlayerStats.Instance.strengthValue.ToString(CultureInfo.InvariantCulture);
        dexterityText.text = PlayerStats.Instance.dexterityValue.ToString(CultureInfo.InvariantCulture);
        intelligenceText.text = PlayerStats.Instance.intelligenceValue.ToString(CultureInfo.InvariantCulture);
        vitalityText.text = PlayerStats.Instance.vitalityValue.ToString(CultureInfo.InvariantCulture);
        UpdateHealth();
        UpdateMaxHealth();
        UpdateUpgradeButtons();
    }

    public void UpdateHealth()
    {
        healthSlider.value = PlayerHealth.Instance.currentHealth;
        healthText.text = Mathf.RoundToInt(PlayerHealth.Instance.currentHealth).ToString(CultureInfo.InvariantCulture);
    }
    
    public void UpdateMaxHealth() => healthSlider.maxValue = PlayerHealth.Instance.maxHealth;

    public void UpdateUpgradeButtons()
    {
        UpdateDecreaseAgility();
        UpdateDecreaseStrength();
        UpdateDecreaseVitality();
        UpdateDecreaseDexterity();
        UpdateDecreaseIntelligence();
        UpdateIncreaseAgility();
        UpdateIncreaseStrength();
        UpdateIncreaseVitality();
        UpdateIncreaseDexterity();
        UpdateIncreaseIntelligence();
    }
    void UpdateDecreaseAgility()
    {
        agilityText.text = PlayerStats.Instance.agilityValue.ToString(CultureInfo.InvariantCulture);
        
        if (PlayerStats.Instance.agilityValue <= 1f)
        {
            decreaseAGL.interactable = false;
            PlayerStats.Instance.agilityValue = 1f;
        }
        else
        {
            decreaseAGL.interactable = true;
        }
    }
    void UpdateIncreaseAgility()
    {
        agilityText.text = PlayerStats.Instance.agilityValue.ToString(CultureInfo.InvariantCulture);

        increaseAGL.interactable = !(PointsManager.Instance.upgradeCostAGL > PointsManager.Instance.GetCurrentPoints());
    }

    void UpdateDecreaseStrength()
    {
        strengthText.text = PlayerStats.Instance.strengthValue.ToString(CultureInfo.InvariantCulture);

        if (PlayerStats.Instance.strengthValue <= 1f)
        {
            decreaseSTR.interactable = false;
            PlayerStats.Instance.strengthValue = 1f;
        }
        else
        {
            decreaseSTR.interactable = true;
        }
    }
    void UpdateIncreaseStrength()
    {
        strengthText.text = PlayerStats.Instance.strengthValue.ToString(CultureInfo.InvariantCulture);

        increaseSTR.interactable = !(PointsManager.Instance.upgradeCostSTR > PointsManager.Instance.GetCurrentPoints());
    }

    void UpdateDecreaseDexterity()
    {
        dexterityText.text = PlayerStats.Instance.dexterityValue.ToString(CultureInfo.InvariantCulture);
        
        if (PlayerStats.Instance.dexterityValue <= 1f)
        {
            decreaseDEX.interactable = false;
            PlayerStats.Instance.dexterityValue = 1f;
        }
        else
        {
            decreaseDEX.interactable = true;
        }
    } 
    void UpdateIncreaseDexterity()
    {
        dexterityText.text = PlayerStats.Instance.dexterityValue.ToString(CultureInfo.InvariantCulture);

        increaseDEX.interactable = !(PointsManager.Instance.upgradeCostDEX > PointsManager.Instance.GetCurrentPoints());
    }

    void UpdateDecreaseIntelligence()
    {
        intelligenceText.text = PlayerStats.Instance.intelligenceValue.ToString(CultureInfo.InvariantCulture);
        
        if (PlayerStats.Instance.intelligenceValue <= 1f)
        {
            decreaseINT.interactable = false;
            PlayerStats.Instance.intelligenceValue = 1f;
        }
        else
        {
            decreaseINT.interactable = true;
        }
    }
    void UpdateIncreaseIntelligence()
    {
        intelligenceText.text = PlayerStats.Instance.intelligenceValue.ToString(CultureInfo.InvariantCulture);

        increaseINT.interactable = !(PointsManager.Instance.upgradeCostINT > PointsManager.Instance.GetCurrentPoints());
    }
    void UpdateDecreaseVitality()
    {
        vitalityText.text = PlayerStats.Instance.vitalityValue.ToString(CultureInfo.InvariantCulture);
        
        if (PlayerStats.Instance.vitalityValue <= 1f)
        {
            decreaseVIT.interactable = false;
            PlayerStats.Instance.vitalityValue = 1f;
        }
        else
        {
            decreaseVIT.interactable = true;
        }
    }
    void UpdateIncreaseVitality()
    {
        vitalityText.text = PlayerStats.Instance.vitalityValue.ToString(CultureInfo.InvariantCulture);

        increaseVIT.interactable = !(PointsManager.Instance.upgradeCostVIT > PointsManager.Instance.GetCurrentPoints());
    }

    public void UpdatePoints() => totalPointsText.text = "Points: " + PointsManager.Instance.GetCurrentPoints().ToString(CultureInfo.InvariantCulture);

    /*public void ApplyStats()
    {
        PlayerPrefs.SetFloat("StrengthValue", PlayerStats.Instance.strengthValue);
        PlayerPrefs.SetFloat("AgilityValue", PlayerStats.Instance.agilityValue);
        PlayerPrefs.SetFloat("DexterityValue", PlayerStats.Instance.dexterityValue);
        PlayerPrefs.SetFloat("VitalityValue", PlayerStats.Instance.vitalityValue);
        PlayerPrefs.SetFloat("IntelligenceValue", PlayerStats.Instance.intelligenceValue);
        PlayerPrefs.SetFloat("TotalPoints", PointsManager.Instance.GetCurrentPoints());
        PlayerPrefs.SetFloat("UpgradeSTR", PointsManager.Instance.upgradeCostSTR);
        PlayerPrefs.SetFloat("UpgradeAGL", PointsManager.Instance.upgradeCostAGL);
        PlayerPrefs.SetFloat("UpgradeDEX", PointsManager.Instance.upgradeCostDEX);
        PlayerPrefs.SetFloat("UpgradeVIT", PointsManager.Instance.upgradeCostVIT);
        PlayerPrefs.SetFloat("UpgradeINT", PointsManager.Instance.upgradeCostINT);
    }*/

    public void LoadStats()
    {
        PlayerStats.Instance.strengthValue = PlayerPrefs.HasKey("StrengthValue") ? PlayerPrefs.GetFloat("StrengthValue") : 1f;
        PlayerStats.Instance.agilityValue = PlayerPrefs.HasKey("AgilityValue") ? PlayerPrefs.GetFloat("AgilityValue") : 1f;
        PlayerStats.Instance.dexterityValue = PlayerPrefs.HasKey("DexterityValue") ? PlayerPrefs.GetFloat("DexterityValue") : 1f;
        PlayerStats.Instance.vitalityValue = PlayerPrefs.HasKey("VitalityValue") ? PlayerPrefs.GetFloat("VitalityValue") : 1f;
        PlayerStats.Instance.intelligenceValue = PlayerPrefs.HasKey("IntelligenceValue") ? PlayerPrefs.GetFloat("IntelligenceValue") : 1f;
        PointsManager.Instance.totalPoints = PlayerPrefs.HasKey("TotalPoints") ? PlayerPrefs.GetFloat("TotalPoints") : 0f;
        PointsManager.Instance.upgradeCostSTR = PlayerPrefs.HasKey("UpgradeSTR") ? PlayerPrefs.GetFloat("UpgradeSTR") : 25;
        PointsManager.Instance.upgradeCostAGL = PlayerPrefs.HasKey("UpgradeAGL") ? PlayerPrefs.GetFloat("UpgradeAGL") : 25;
        PointsManager.Instance.upgradeCostDEX = PlayerPrefs.HasKey("UpgradeDEX") ? PlayerPrefs.GetFloat("UpgradeDEX") : 25;
        PointsManager.Instance.upgradeCostINT = PlayerPrefs.HasKey("UpgradeINT") ? PlayerPrefs.GetFloat("UpgradeINT") : 25;
        PointsManager.Instance.upgradeCostVIT = PlayerPrefs.HasKey("UpgradeVIT") ? PlayerPrefs.GetFloat("UpgradeVIT") : 25;
    }
}
