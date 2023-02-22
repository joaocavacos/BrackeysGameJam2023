using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float nextCast;

    protected virtual void Start()
    {
        Caster.abilitiesSelected.Add(this);
    }

    public float abilityCooldown { get { return cooldown; } set { cooldown = value; } }
    public float nextCastCooldown { get { return nextCast; } set { nextCast = value; } }

    public abstract void Cast();
}
