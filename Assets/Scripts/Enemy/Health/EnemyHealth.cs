using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth; 
    [SerializeField] private int pointsToDrop;
    private Animator enemyAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        enemyAnimator.SetTrigger("Hurt");
        DamagePopup.Create(transform.position + (Vector3.up * 2), Mathf.RoundToInt(damage), false);
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        PointsManager.Instance.IncreaseKillPoints(pointsToDrop);
        enemyAnimator.SetTrigger("Die");
        Destroy(gameObject, 0.35f);
    }
}
