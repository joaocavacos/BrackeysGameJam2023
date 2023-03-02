using UnityEngine;
using TMPro;
using System;

public class HoverManager : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text cooldownText;
    public TMP_Text descriptionText;
    public RectTransform hoverWindow;

    public static Action<string, string, string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable() {
        OnMouseHover += ShowInfo;
        OnMouseLoseFocus += HideInfo;
    }

    private void OnDisable() {
        OnMouseHover -= ShowInfo;
        OnMouseLoseFocus -= HideInfo;
    }

    void Start()
    {
        HideInfo();
    }

    private void ShowInfo(string title, string cooldown, string description, Vector2 mousePos){
        titleText.text = title;
        cooldownText.text = cooldown;
        descriptionText.text = description;

        hoverWindow.gameObject.SetActive(true);
        hoverWindow.transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void HideInfo(){
        titleText.text = default;
        cooldownText.text = default;
        descriptionText.text = default;
        hoverWindow.gameObject.SetActive(false);
    }

}
