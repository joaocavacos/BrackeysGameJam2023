using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Physics/Graphics")]
    [SerializeField] private float moveSpeed = 2f;
    private Animator enemyAnim;
    private Transform enemyGFX;

    [Header("Patrol")]
    protected Transform playerTarget;
    [SerializeField] private Transform[] waypoints;


    [Header("Attack")]
    [SerializeField] protected float chaseDistance = 5f;
    protected LayerMask playerLayer;
    [SerializeField] protected float attackDamage = 3f;
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected float attackRate = 2f;
    private bool canAttack = true;
    
    private Transform currentPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = gameObject.transform.Find("EnemyGFX");
        playerTarget = PlayerController.Instance.gameObject.transform;
        playerLayer = LayerMask.GetMask("Player");
        enemyAnim = enemyGFX.GetComponent<Animator>();
        currentPoint = waypoints[Random.Range(0, waypoints.Length)];
    }

    void Update() 
    {
        Flip();
        enemyAnim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if(!FindPlayer() && !IsAttackRange()) Patrol();
        else if(FindPlayer() && !IsAttackRange()) ChasePlayer();
        else if(FindPlayer() && IsAttackRange() && canAttack) StartCoroutine(AttackingRate());
    }

    private void Patrol()
    {
        //StopAllCoroutines();
        Vector3 directionToWaypoint = (currentPoint.position - transform.position).normalized;

        rb.velocity = moveSpeed * new Vector2(directionToWaypoint.x, 0f);

        if(Vector2.Distance(transform.position, currentPoint.position) <= 0.5f && currentPoint == waypoints[1]) currentPoint = waypoints[0];
        else if(Vector2.Distance(transform.position, currentPoint.position) <= 0.5f && currentPoint == waypoints[0]) currentPoint = waypoints[1];
    }

    private void ChasePlayer(){
        
        //Debug.Log("Start chasing player");
        //StopAllCoroutines();

        Vector3 direction = (playerTarget.position - transform.position).normalized;

        rb.velocity = moveSpeed * new Vector2(direction.x, 0f);
    }

    public virtual void Attack() {
        enemyAnim.SetTrigger("Attack");
    }

    private IEnumerator AttackingRate(){
        canAttack = false;
        Attack();
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }

    private bool FindPlayer(){  
        return Physics2D.OverlapCircle(transform.position, chaseDistance, playerLayer);
    }
    private bool IsAttackRange(){
        return Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
    }

    private void Flip()
    {
        if(rb.velocity.x >= 0.01f) enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        else if (rb.velocity.x <= -0.01f) enemyGFX.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
