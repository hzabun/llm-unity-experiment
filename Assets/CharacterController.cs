using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of character movement
    public float jumpForce = 7.0f; // Force of character jump
    private bool isGrounded; // To check if the character is on the ground


    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        // Check if the character is moving
        if (moveHorizontal != 0)
        {
            // Flip the character sprite
            transform.localScale = new Vector3(Mathf.Sign(moveHorizontal*-1), 1, 1);
        }
    }


    void Jump()
    {
        // Check if the space bar is pressed and the character is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    void Attack()
    {
        // Check for attack input (e.g., pressing the 'K' key)
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("isAttacking");
        }
    }

    // Check if the character collides with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
