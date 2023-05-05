using UnityEngine;

public class ChainLightning : Ability
{
    [SerializeField] private GameObject lightingPrefab;
    [SerializeField] private Vector3 distanceToCast;

    public override void Cast(){
        GameObject lighting = Instantiate(lightingPrefab,
            PlayerController.Instance.transform.position + new Vector3(PlayerController.Instance.transform.localScale.x * distanceToCast.x, distanceToCast.y, distanceToCast.z),
            Quaternion.identity);
        Destroy(lighting, 5f);
    }
    
}
