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

    [SerializeField] private List<int> statusEffectTickTimer = new List<int>();

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
        DamagePopup.Create(transform.position + (Vector3.up * 2), Mathf.RoundToInt(damage));
        playerAnim.SetTrigger("Hurt");
        if (currentHealth <= 0){
            playerAnim.SetTrigger("Die");
            Invoke("Die", 0.5f);
        }
    }
    
    //ticks => number of times the player will get affected by status effect | statusTickTime => activates ticks per statusTickTime
    public void ApplyStatusEffect(float damage, int ticks, float statusTickTime){ 
        if(statusEffectTickTimer.Count <= 0){
            statusEffectTickTimer.Add(ticks);
            StartCoroutine(StatusEffect(damage, statusTickTime));
        }else{
            statusEffectTickTimer.Add(ticks);
        }
    }

    private IEnumerator StatusEffect(float damage, float statusTickTime){
        while(statusEffectTickTimer.Count > 0){
            for (int i = 0; i < statusEffectTickTimer.Count; i++)
            {
                statusEffectTickTimer[i]--;
            }
            LoseHealth(damage);
            statusEffectTickTimer.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(statusTickTime);
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
