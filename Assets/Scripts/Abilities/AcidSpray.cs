using UnityEngine;

public class AcidSpray : Ability
{
    [SerializeField] private GameObject acidPrefab;
    [SerializeField] private Vector3 distanceToCast;

    public override void Cast(){
        GameObject acid = Instantiate(acidPrefab, PlayerController.Instance.transform.position + (PlayerController.Instance.transform.localScale.x * distanceToCast), Quaternion.identity);
        Destroy(acid, 3f);
    }
}
