using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private void Awake() {
        textMesh = GetComponent<TextMeshPro>();
        Destroy(this.gameObject, 0.3f);
    }

    public static DamagePopup Create(Vector3 pos, int damageAmount){
        Transform damagePopupTransform = Instantiate(UIManager.Instance.damagePopupObject, pos, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    public void Setup(float damageAmount){
        textMesh.SetText(damageAmount.ToString());
    }
    
}
