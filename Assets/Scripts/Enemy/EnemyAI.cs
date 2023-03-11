using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Physics/Graphics")]
    [SerializeField] private float moveSpeed = 2f;
    private Transform enemyGFX;

    [Header("Patrol")]
    private Transform playerTarget;
    [SerializeField] private Transform[] waypoints;


    [Header("Attack")]
    [SerializeField] private float chaseDistance = 5f;
    private LayerMask playerMask;
    [SerializeField] private float attackDamage = 3f;
    [SerializeField] private float attackRange = 2f;
    
    private Transform currentPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = gameObject.transform.Find("EnemyGFX");
        playerTarget = PlayerController.Instance.gameObject.transform;
        playerMask = LayerMask.GetMask("Player");
        currentPoint = waypoints[Random.Range(0, waypoints.Length)];
    }

    private void Update() 
    {
        Flip();
        
        if(!FindPlayer() && !IsAttackRange()) Patrol();
        else if(FindPlayer() && !IsAttackRange()) ChasePlayer();
        else if(FindPlayer() && IsAttackRange()) Attack();
    }

    private void Patrol()
    {
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == waypoints[1]) rb.velocity = new Vector2(moveSpeed, 0f);
        else rb.velocity = new Vector2(-moveSpeed, 0f);

        if(Vector2.Distance(transform.position, currentPoint.position) <= 0.5f && currentPoint == waypoints[1]) currentPoint = waypoints[0];
        else if(Vector2.Distance(transform.position, currentPoint.position) <= 0.5f && currentPoint == waypoints[0]) currentPoint = waypoints[1];
    }

    private void ChasePlayer(){
        
        Debug.Log("Start chasing player");

        Vector3 direction = (playerTarget.position - transform.position).normalized;

        rb.velocity = moveSpeed * new Vector2(direction.x, 0f);
    }

    public virtual void Attack() {}

    private bool FindPlayer(){  
        return Physics2D.OverlapCircle(transform.position, chaseDistance, playerMask);
    }
    private bool IsAttackRange(){
        return Physics2D.OverlapCircle(transform.position, attackRange, playerMask);
    }

    private void Flip()
    {
        if(rb.velocity.x >= 0.01f) enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        else if (rb.velocity.x <= 0.01f) enemyGFX.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
