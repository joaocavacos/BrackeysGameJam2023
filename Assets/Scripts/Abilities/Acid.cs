using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float abilityDamage;
    private EnemyHealth enemy;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            enemy = other.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            enemy = null;
        }
    }

    private void Update() {
        
        if(enemy != null){
            enemy.LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
        }
        
    }
}
