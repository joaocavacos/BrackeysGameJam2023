using UnityEngine;
using System.Collections;

public class Demon : EnemyAI
{

    [Header("Unique Ability")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackPointRange;
    [SerializeField] private float overtimeDamage;

    public override void Attack()
    {
        base.Attack();
        
        var player = Physics2D.OverlapCircle(attackPoint.position, attackPointRange, playerLayer);

        if(player){
            PlayerHealth.Instance.LoseHealth(attackDamage);
            PlayerHealth.Instance.ApplyStatusEffect(overtimeDamage, 4, 1f); //deal overtimeDamage, 4 times in 4 seconds
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackPointRange);
    }

}
