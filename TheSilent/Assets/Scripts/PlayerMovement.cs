using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    //[SerializeField] private float JumpHeight = 12f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float runSpeed = 10f;
    private float horizontal;
    private bool isFacingRight = true;

    [Header("GroundCheck")]
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    [Header("Animate")]
    public Animator animate;

    [Header("Dialogue")]
    [SerializeField] private DialogueUi dialogueUi;
    public DialogueUi DialogueUi => dialogueUi;
    public DialogueInteract Interact { get; set; }

    void Start()
    {
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dialogueUi.IsOpen) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        //Jump();//fungsi loncat
        Flip();
        isGrounded();
        Run();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interact != null)
            {
                Interact.Interact(this);
            }
        }
    }

    private void Movement()
    {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            animate.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
            animate.SetFloat("yVelocity", rb.velocity.y);
            Flip();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded())
        {
            rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
            animate.SetBool("IsRunning", true);
        }
        else
        {
            animate.SetBool("IsRunning", false);
        }
    }

    /*
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            animate.SetBool("isJumping", true);
        }
        
    }
    */
}
    