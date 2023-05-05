using UnityEngine;

public class AcidSpray : Ability
{
    [SerializeField] private GameObject acidPrefab;
    [SerializeField] private Vector3 distanceToCast;

    public override void Cast(){
        GameObject acid = Instantiate(acidPrefab, 
            PlayerController.Instance.transform.position + new Vector3(PlayerController.Instance.transform.localScale.x * distanceToCast.x, distanceToCast.y, distanceToCast.z), 
            Quaternion.identity);
        Destroy(acid, 3f);
    }
}
