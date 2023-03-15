using UnityEngine;

public class Watcher : EnemyAI
{

    [SerializeField] private GameObject projectilePrefab;
    
    public override void Attack(){
        base.Attack();

        Vector3 playerDir = (playerTarget.position - transform.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, transform.position + (playerDir.x * Vector3.right), projectilePrefab.transform.rotation);
    }
    
}
