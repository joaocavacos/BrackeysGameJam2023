using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnimator;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private float moveX;
    private bool facingRight = true;
    

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!UIManager.Instance.isPaused)
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
