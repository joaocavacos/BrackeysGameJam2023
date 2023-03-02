using UnityEngine;

public class ForcePush : Ability
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float abilityDamage;
    [SerializeField] private float forceStrength;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;

    public override void Cast(){
        var enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach (var enemy in enemies)
        {
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            enemy.GetComponent<EnemyHealth>().LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
            enemyRb.AddForce((PlayerController.Instance.transform.localScale.x * Vector2.right) * forceStrength, ForceMode2D.Impulse);
        }
    }
}
