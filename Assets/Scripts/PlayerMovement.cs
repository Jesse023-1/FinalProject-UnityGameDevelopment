using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 actionValue;
    private Rigidbody2D rbPlayer;

    public float speed = 100f;
    public float jump = 10f;

    public bool touchGround = false;
    public bool hitBoxRight = true;

    private Animator anim;
    public SpriteRenderer playerSprite;
    private SwordAttack attack;

    private PlayerHealth health;

    AudioManager manager;

    [SerializeField]
    private AudioClip slash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        attack = GetComponentInChildren<SwordAttack>();
        health = GetComponent<PlayerHealth>();
        manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (health.isDead)
        {
            anim.SetBool("isWalking", false);
            return;
        }
        float x_pos = actionValue.x;
        float y_pos = actionValue.y;

        bool isWalking = Mathf.Abs(x_pos) > 0 || Mathf.Abs(y_pos) > 0;
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", touchGround);

        anim.SetFloat("X", x_pos);
        anim.SetFloat("Y", y_pos);
    }

    void FixedUpdate()
    {

        if (health.isKnockedBack)
        {
            return;
        }

        if (!health.isDead)
        {
            Vector2 movement = actionValue;

            if (actionValue.x < 0)
            {
                hitBoxRight = false;
                playerSprite.flipX = true;
            }
            else if (actionValue.x > 0)
            {
                hitBoxRight = true;
                playerSprite.flipX = false;
            }

            rbPlayer.linearVelocity = new Vector2(movement.x * speed, rbPlayer.linearVelocity.y);
        }
        else
        {
            rbPlayer.linearVelocity = Vector2.zero;
        }

    }

    public void OnMove(InputValue value)
    {
        if (health.isDead)
        {
            actionValue = Vector2.zero;
            return;
        }
        actionValue = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (health.isDead || health.isKnockedBack) return;
        anim.SetTrigger("jumped");
        if (touchGround)
        {
            rbPlayer.AddForce(Vector2.up * jump, ForceMode2D.Impulse); ;
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            manager.PlaySFX(slash);
            if(health.isDead || health.isKnockedBack)
            {
                return;
            }
            Debug.Log("Attack Button Pressed");
            attack.OnAttack();
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = false;
        }
    }
}

