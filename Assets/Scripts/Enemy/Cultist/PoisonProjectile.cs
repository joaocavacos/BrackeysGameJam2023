using UnityEngine;

public class PoisonProjectile : Projectile
{
    [SerializeField] private float overtimeDamage;

    protected override void DealDamage()
    {
        base.DealDamage();
        PlayerHealth.Instance.ApplyStatusEffect(overtimeDamage, 4, 0.5f);
    }
}
