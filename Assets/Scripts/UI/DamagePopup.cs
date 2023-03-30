using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    private void Awake() {
        textMesh = GetComponent<TextMeshPro>();
        Destroy(this.gameObject, 0.3f);
    }

    public static DamagePopup Create(Vector3 pos, int damageAmount, bool isCritical){
        Transform damagePopupTransform = Instantiate(UIManager.Instance.damagePopupObject, pos, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        
        damagePopup.Setup(damageAmount, isCritical);

        return damagePopup;
    }

    private void Setup(float damageAmount, bool isCritical){
        textMesh.SetText(damageAmount.ToString());
        
        if (!isCritical)
        {
            textMesh.fontSize = 8;
            textColor = new Color(1, 0.7f, 0.3f, 1f);
        }
        else
        {
            textMesh.fontSize = 12;
            textColor = Color.red;
        }
        textMesh.color = textColor;
    }
    
}
