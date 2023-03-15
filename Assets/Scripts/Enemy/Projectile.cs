using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float attackDamage;
    [SerializeField] private float projectileSpeed;
    private Vector3 playerDirection;

    private void Start() {
        Destroy(gameObject, 3f);
        playerDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
    }

    private void Update() {
        transform.Translate(playerDirection * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            PlayerHealth.Instance.LoseHealth(attackDamage);
            Destroy(gameObject);
        }
    }
}
