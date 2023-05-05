using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShards : Ability
{
    [SerializeField] private GameObject shardPrefab;

    public override void Cast(){
        GameObject shard1 = Instantiate(shardPrefab, PlayerController.Instance.transform.position + (PlayerController.Instance.transform.localScale.x * new Vector3(1f, -0.5f, 0) ), shardPrefab.transform.rotation);
        GameObject shard2 = Instantiate(shardPrefab, PlayerController.Instance.transform.position + (PlayerController.Instance.transform.localScale.x * new Vector3(1f, 0f, 0)), shardPrefab.transform.rotation);
        GameObject shard3 = Instantiate(shardPrefab, PlayerController.Instance.transform.position + (PlayerController.Instance.transform.localScale.x * new Vector3(1f, 0.5f, 0)), shardPrefab.transform.rotation);
        Destroy(shard1, 5f);
        Destroy(shard2, 5f);
        Destroy(shard3, 5f);
    }    

}
