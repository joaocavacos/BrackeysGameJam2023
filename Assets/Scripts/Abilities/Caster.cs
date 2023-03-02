using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{

    //MODIFY TO SINGLE SCRIPT, NO NEED TO REFERENCE ABILITYMANAGER

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > AbilityManager.Instance.abilityList[0].nextCastCooldown)
        {
            AbilityManager.Instance.abilityList[0].nextCastCooldown = Time.time + AbilityManager.Instance.abilityList[0].abilityCooldown;
            AbilityManager.Instance.abilityList[0].Cast();
        }

        if(Input.GetKeyDown(KeyCode.E) && Time.time > AbilityManager.Instance.abilityList[1].nextCastCooldown){
            AbilityManager.Instance.abilityList[1].nextCastCooldown = Time.time + AbilityManager.Instance.abilityList[1].abilityCooldown;
            AbilityManager.Instance.abilityList[1].Cast();
        }
    }

}
