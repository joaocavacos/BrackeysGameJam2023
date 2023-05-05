using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caster : MonoBehaviour
{

    //MODIFY TO SINGLE SCRIPT, NO NEED TO REFERENCE ABILITYMANAGER

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > AbilityManager.Instance.abilityList[0].nextCastCooldown)
        {
            AbilityManager.Instance.abilityList[0].nextCastCooldown = Time.time + AbilityManager.Instance.abilityList[0].abilityCooldown;
            AbilityManager.Instance.abilityList[0].Cast();
            StartCoroutine(DisableAbilityImage(AbilityManager.Instance.ability1Image, AbilityManager.Instance.abilityList[0].abilityCooldown));
        }

        if(Input.GetKeyDown(KeyCode.E) && Time.time > AbilityManager.Instance.abilityList[1].nextCastCooldown){
            AbilityManager.Instance.abilityList[1].nextCastCooldown = Time.time + AbilityManager.Instance.abilityList[1].abilityCooldown;
            AbilityManager.Instance.abilityList[1].Cast();
            StartCoroutine(DisableAbilityImage(AbilityManager.Instance.ability2Image, AbilityManager.Instance.abilityList[1].abilityCooldown));
        }
    }

    private IEnumerator DisableAbilityImage(Image image, float cooldown)
    {
        var StartColor = image.color;
        image.color = new Color(1f, 1f, 1f, 0.35f);
        yield return new WaitForSeconds(cooldown);
        image.color = StartColor;
    }

    

}
