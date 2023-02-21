using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    public abstract void IncreaseStrength();
    public abstract void DecreaseStrength();
    public abstract void IncreaseDexterity();
    public abstract void DecreaseDexterity();
    public abstract void IncreaseIntelligence();
    public abstract void DecreaseIntelligence();
    public abstract void IncreaseVitality();
    public abstract void DecreaseVitality();
    public abstract void IncreaseAgility();
    public abstract void DecreaseAgility();
}
