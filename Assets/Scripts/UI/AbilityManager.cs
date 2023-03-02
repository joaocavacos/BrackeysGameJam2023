using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AbilityManager : StaticInstance<AbilityManager>
{

    public List<Ability> abilityList;

    [SerializeField] private List<Ability> clonedAbilityList;

    [SerializeField] private TMP_Text abilities1Text;
    [SerializeField] private TMP_Text abilities2Text;
    [SerializeField] private Image ability1Image;
    [SerializeField] private Image ability2Image;

    public int abilityCount = 0;


    protected override void Awake() {
        base.Awake();
        abilityList = new List<Ability>();
    }

    public void AddAbility(Ability ability) => abilityList.Insert(0, ability);

    public void PickAbility(Button btn){

        var abilityName = btn.name;

        for (int i = 0, count = abilityList.Count; i < count; i++)
        {
            if(abilityList[i].AbilityName == abilityName){
                var ability = abilityList[i];
                abilityList.Remove(ability);
                abilityList.Insert(0, ability);
                abilityCount++;
                break;
            }
        }
        
        if(abilityCount == 1){ 
            abilities1Text.transform.position = abilityList[0].AbilityPickBtn.transform.position;
        }else if(abilityCount >= 2){
            abilities1Text.transform.position = abilityList[0].AbilityPickBtn.transform.position;
            abilities2Text.transform.position = abilityList[1].AbilityPickBtn.transform.position;
            UIManager.Instance.UpdateApply();
        }

    }

    public void ResetCount() => abilityCount = 0;


    public void ApplyAbilityImages(){
        ability1Image.sprite = abilityList[0].AbilityImage;
        ability2Image.sprite = abilityList[1].AbilityImage;
    }

    public void UpdateAbilitiesText(){
        abilities1Text.transform.position = abilityList[0].gameObject.transform.position;
        abilities2Text.transform.position = abilityList[1].gameObject.transform.position;
    }
}
