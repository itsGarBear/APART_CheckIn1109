using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5;

    private Rigidbody2D rb;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            TryJump();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 dir = (transform.right * x) * moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    private void TryJump()
    {
        if (Physics2D.OverlapCircle(transform.position, .51f, groundLayer))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
