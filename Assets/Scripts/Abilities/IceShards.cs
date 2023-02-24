using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShards : Ability
{
    [SerializeField] private GameObject shardPrefab;

    public override void Cast(){
        GameObject shard = Instantiate(shardPrefab, PlayerController.Instance.transform.position + Vector3.right, shardPrefab.transform.rotation);
        Destroy(shard, 5f);
    }    

}
