using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;
    [HideInInspector] public Rigidbody2D rb;
    private Animator playerAnimator;

    private Vector3 playerStartPos;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private float moveX;
    [HideInInspector] public bool facingRight = true;
    

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStartPos = transform.position;
    }

    void Update()
    {
        if (!SceneManager.Instance.isPaused)
        {
            GetInput();
            if (Input.GetButton("Jump") && isGrounded())
            {
                Jump();
                playerAnimator.SetBool("IsJumping", true);
            }
            else if (isGrounded())
            {
                playerAnimator.SetBool("IsJumping", false);
            }
            playerAnimator.SetFloat("Speed", Mathf.Abs(moveX));
        }
    }

    void FixedUpdate()
    {
        Move();
        
        if(moveX > 0 && !facingRight) Flip();
        if(moveX < 0 && facingRight) Flip();
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveX * moveSpeed * PlayerStats.Instance.agilityValue, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0f, jumpForce);
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void ResetStartingPosition()
    {
        transform.position = playerStartPos;
    }

    private bool isGrounded()
    {
        float distanceToGround = 1.05f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundLayer);

        if (hit.collider != null) return true;
        
        return false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1.05f, Color.red);
    }
}
