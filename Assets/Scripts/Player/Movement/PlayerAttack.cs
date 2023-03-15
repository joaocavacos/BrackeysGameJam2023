using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRate;
    private bool canAttack = true;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canAttack)
        {
            StartCoroutine(AttackingRate());
        }
    }

    private void Attack()
    {
        var enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        playerAnimator.SetTrigger("Attack");
        
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().LoseHealth(attackDamage * PlayerStats.Instance.strengthValue);
        }
    }

    private IEnumerator AttackingRate()
    {
        canAttack = false;
        Attack();
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }
}
