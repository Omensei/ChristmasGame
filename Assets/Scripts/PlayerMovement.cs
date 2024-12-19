using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jump;
    private Boolean isGrounded = true;
    private float store;
    Boolean isFirePressed;
    float horizontal;
    Boolean isJumpPressed;


    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        store = rb.gravityScale;
    }

    private void Update()
    {

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            isFirePressed = true;

        }

        if (Input.GetButtonUp("Fire1"))
        {

            isFirePressed = false;
            isGrounded = true;

        }

        if (Input.GetButtonDown("Jump")){
            isJumpPressed = true;
            

        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumpPressed = false;
            

        }

    }

    private void FixedUpdate()
    {


        if (isFirePressed)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }

        if (!isFirePressed)
        {
            RestoreGravity();
        }

        if (isJumpPressed && isGrounded && rb.gravityScale > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isGrounded = false;
            
           
            
        }


        if (rb.gravityScale > 0)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }

    


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void RestoreGravity()
    {
        // Safeguard to ensure gravity is restored
        if (rb.gravityScale == 0)
        {
            rb.gravityScale = store;
            Debug.Log($"Gravity restored to: {store}");
        }
    }
}


