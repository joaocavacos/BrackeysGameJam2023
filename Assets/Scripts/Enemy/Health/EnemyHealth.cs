using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth; 
    [SerializeField] private int pointsToDrop;
    [SerializeField] private Animator enemyAnimator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        enemyAnimator.SetTrigger("Hurt");
        if(currentHealth <= 0) Die();
    }

    public void Die()
    {
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        PointsManager.Instance.IncreaseKillPoints(pointsToDrop);
        enemyAnimator.SetTrigger("Die");
        Destroy(gameObject, 0.35f);
    }
}
