using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of character movement
    public float jumpForce = 8.0f; // Force of character jump

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Ensure the character doesn't rotate and stays upright
        rb.freezeRotation = true;
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // Check if the character is moving to toggle the running animation
        bool isMoving = moveHorizontal != 0;
        animator.SetBool("isRunning", isMoving);

        // Flip character when moving left-right
        if (isMoving)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveHorizontal * -1), 1, 1);
        }
    }

    void Jump()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Simple vertical velocity check instead of isGrounded
            if (Mathf.Approximately(rb.velocity.y, 0))
            {
                rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                animator.SetTrigger("isJumping");
            }
        }
    }

    void Attack()
    {
        // Check for attack input (e.g., pressing the 'K' key)
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}

