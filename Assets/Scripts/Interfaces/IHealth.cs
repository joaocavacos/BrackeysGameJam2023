using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public void LoseHealth(float damage);
    public void Die();
}
