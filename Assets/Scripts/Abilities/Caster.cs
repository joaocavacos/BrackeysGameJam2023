using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : StaticInstance<Caster>
{
    public List<Ability> abilityList;

    protected override void Awake()
    {
        base.Awake();        
        abilityList = new List<Ability>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > abilityList[0].nextCastCooldown)
        {
            abilityList[0].nextCastCooldown = Time.time + abilityList[0].abilityCooldown;
            abilityList[0].Cast();
        }

        if(Input.GetKeyDown(KeyCode.E) && Time.time > abilityList[1].nextCastCooldown){
            abilityList[1].nextCastCooldown = Time.time + abilityList[1].abilityCooldown;
            abilityList[1].Cast();
        }
    }

    public void AddAbility(Ability ability) => abilityList.Add(ability);

}
