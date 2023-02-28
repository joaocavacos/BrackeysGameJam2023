using UnityEngine;

public class Lighting : MonoBehaviour
{
    [SerializeField] private float abilityDamage;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<EnemyHealth>().LoseHealth(abilityDamage * PlayerStats.Instance.intelligenceValue);
        }
    }
    
}
