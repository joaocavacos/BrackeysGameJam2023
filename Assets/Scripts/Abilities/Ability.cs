using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float nextCast;

    public float abilityCooldown { get { return cooldown; } set { cooldown = value; } }
    public float nextCastCooldown { get { return nextCast; } set { nextCast = value; } }

    public abstract void Cast();
    
    protected void Start()
    {
        Caster.Instance.AddAbility(this);
    }
}
