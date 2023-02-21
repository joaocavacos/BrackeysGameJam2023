using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public static PlayerHealth Instance;
    
    public float currentHealth;
    public float maxHealth;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }
    
    void Start()
    {
        maxHealth = 100 * PlayerStats.Instance.vitalityValue;
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        maxHealth = 100 * PlayerStats.Instance.vitalityValue;
        currentHealth = maxHealth;
    }

    void Update()
    {
        //HealthChecker();
        UIManager.Instance.UpdateHealth();
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) Die();
    }

    public void Die()
    {
        UIManager.Instance.EndGame();
        gameObject.SetActive(false);
    }

    private void HealthChecker()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}