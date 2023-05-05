using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [SerializeField] private float abilityDamage;
    [SerializeField] private float shardSpeed;
    private float startScale;
    
    private void OnEnable() {
        startScale = PlayerController.Instance.transform.localScale.x;
    }

    private void Update() {
        transform.Translate(transform.right * (-startScale * shardSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            PlayerHealth.Instance.LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


}
