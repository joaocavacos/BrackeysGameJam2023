using UnityEngine;

public class Lighting : MonoBehaviour
{
    [SerializeField] private float abilityDamage;
    private EnemyHealth enemy;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            enemy = other.GetComponent<EnemyHealth>();
            enemy.LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
        }
    }
    
}
