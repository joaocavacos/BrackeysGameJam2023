using UnityEngine;

public class Demon : EnemyAI
{
    [SerializeField] private Transform attackPoint;

    public override void Attack()
    {
        base.Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
