using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string infoTitle;
    private string infoCooldown;
    private string infoDescription;
    private Button btn;

    private void Start() {
        btn = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowMessage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverManager.OnMouseLoseFocus();
    }

    private void ShowMessage(){
        infoTitle = GetAbility().AbilityName;
        infoCooldown = "Cooldown: " + GetAbility().abilityCooldown + "s";
        infoDescription = "Description: " + GetAbility().AbilityDescription;
        HoverManager.OnMouseHover(infoTitle, infoCooldown, infoDescription, Input.mousePosition);
    }

    private Ability GetAbility(){
        for (int i = 0, count = AbilityManager.Instance.abilityList.Count; i < count; i++)
        {
            if(AbilityManager.Instance.abilityList[i].AbilityName == btn.name){
                var ability = AbilityManager.Instance.abilityList[i];
                return ability;
            }
        }
        return null;
    }

}
