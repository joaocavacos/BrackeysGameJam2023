using UnityEngine;

public class Goblin : EnemyAI
{
    [SerializeField] private Transform attackPoint;

    public override void Attack()
    {
        base.Attack();
        
        var player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if(player){
            PlayerHealth.Instance.LoseHealth(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
