using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    
    private const float BaseCriticalChance = 15f; //15% chance
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private float criticalDamage;
    [SerializeField] private float attackRate;
    
    private bool canAttack = true;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        criticalDamage = attackDamage * 2;
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
        
        foreach (var enemy in enemies)
        {
            var criticalChance = Random.Range(0, 100) < Mathf.RoundToInt(BaseCriticalChance * PlayerStats.Instance.dexterityValue);
            Debug.Log("Critical hit? = " + criticalChance);
            if (criticalChance)
            {
                attackDamage = criticalDamage;
                enemy.GetComponent<EnemyHealth>().LoseHealth(attackDamage * PlayerStats.Instance.strengthValue);
                
            }
            else
            {
                attackDamage = 30f;
                enemy.GetComponent<EnemyHealth>().LoseHealth(attackDamage * PlayerStats.Instance.strengthValue);
            }
            enemy.GetComponent<EnemyAI>().rb.AddForce((PlayerController.Instance.transform.localScale.x * Vector2.right) * 7.5f, ForceMode2D.Impulse);
            DamagePopup.Create(enemy.transform.position + (Vector3.up * 2), Mathf.RoundToInt(attackDamage), criticalChance);
        }
    }

    private IEnumerator AttackingRate()
    {
        canAttack = false;
        playerAnimator.SetTrigger("Attack");
        //Attack();
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }
}
