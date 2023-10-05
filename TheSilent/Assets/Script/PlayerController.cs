using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int maxJumpCount = 2;

    private int jumpCount;

    // Update is called once per frame

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    private void Jump()
        {
            if (jumpCount >= maxJumpCount) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 jumpDirection = new Vector2(0, 1);
                rb.velocity = jumpDirection * jumpSpeed;
                jumpCount++;
            }
        }
    
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontal, 0); //Kanan
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
