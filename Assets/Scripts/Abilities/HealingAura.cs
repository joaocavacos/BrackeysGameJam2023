using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : Ability
{
    [SerializeField] private float healAmount;

    protected override void Start()
    {
        base.Start();
    }

    public override void Cast()
    {
        PlayerHealth.Instance.Heal(healAmount);
        Debug.Log("Healed");
    }
}
