using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>, IHealth
{
    public float currentHealth;
    public float maxHealth;

    private Animator playerAnim;
    
    void Start()
    {
        playerAnim = GetComponent<Animator>();
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
        UIManager.Instance.UpdateHealth();
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        playerAnim.SetTrigger("Hurt");
        if (currentHealth <= 0){
            playerAnim.SetTrigger("Die");
            Invoke("Die", 0.5f);
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void Die()
    {
        SceneManager.Instance.OnGameOver?.Invoke();
    }

}
