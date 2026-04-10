using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    private Vector2 actionValue;
    private Rigidbody2D rbPlayer;

    public float speed = 100f;
    public float jump = 10f;

    public bool touchGround = false;

    public SpriteRenderer playerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 movement = actionValue;

        if(actionValue == Vector2.left)
        {
            playerSprite.flipX = true;
        }
        if (actionValue == Vector2.right)
        {
            playerSprite.flipX = false;
        }

        rbPlayer.linearVelocity = new Vector2(movement.x * speed, rbPlayer.linearVelocity.y);
        
    }

    public void OnMove(InputValue value)
    {
        actionValue = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (touchGround)
        {
            rbPlayer.AddForce(Vector2.up * jump, ForceMode2D.Impulse); ;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            touchGround = false;
        }
    }
}
