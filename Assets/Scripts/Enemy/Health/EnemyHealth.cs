using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private int pointsToDrop;

    private Animator enemyAnimator;
    
    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        enemyAnimator.SetTrigger("Hurt");
        if(currentHealth <= 0) Die();
    }

    public void Die()
    {
        PointsManager.Instance.IncreaseKillPoints(pointsToDrop);
        Destroy(gameObject);
    }
}
