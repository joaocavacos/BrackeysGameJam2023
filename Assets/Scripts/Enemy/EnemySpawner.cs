using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private GameObject enemyPrefab;
    
    private void OnEnable()
    {
        var go = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
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
