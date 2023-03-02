using UnityEngine;

public class ChainLightning : Ability
{
    [SerializeField] private GameObject lightingPrefab;
    [SerializeField] private Vector3 distanceToCast;

    public override void Cast(){
        GameObject lighting = Instantiate(lightingPrefab, PlayerController.Instance.transform.position + (PlayerController.Instance.transform.localScale.x * distanceToCast), Quaternion.identity);
        Destroy(lighting, 5f);
    }
    
}
