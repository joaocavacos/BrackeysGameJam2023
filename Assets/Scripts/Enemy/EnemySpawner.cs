using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<GameObject> enemyPrefabs;
    
    private void OnEnable()
    {
        var go = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count + 1)], transform.position, Quaternion.identity);
        enemyList.Add(go);
    }

    private void OnDisable()
    {
        foreach (var enemy in enemyList.Where(enemy => enemy != null))
        {
            Destroy(enemy);
        }
    }
}
