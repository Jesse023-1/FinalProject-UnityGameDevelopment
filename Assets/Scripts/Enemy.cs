using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;

    Vector2 enemyDirection;

    private Rigidbody2D rbEnemy;

    private Animator anim;
    private SpriteRenderer enemySprite;
    private EnemyHealth health;

    private float speed = 1.0f;

    private float direction = 0.0f;
    public bool hitBoxRight = false;

    private EnemySwordAttack enemyAttack;

    private float attackRange = 0.8f;
    private float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    private bool playerSpotted = false;

    private float detection = 6.0f;



    void Start()
    {

        FindPlayer();
        rbEnemy = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        enemyAttack = GetComponent<EnemySwordAttack>();

    }

    private void Update()
    {

        
        
        //bool isWalking = Mathf.Abs(direction) > 0;
        //anim.SetBool("isWalking", isWalking);

        //anim.SetFloat("X", direction);
    }

    void FixedUpdate()
    {

        if (player == null)
        {
            FindPlayer();

            if (player == null)
            {
                rbEnemy.linearVelocity = Vector2.zero;
                anim.SetBool("isWalking", false);
                return;
            }
        }
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null && playerHealth.isDead)
        {
            playerSpotted = false;
            rbEnemy.linearVelocity = Vector2.zero;
            anim.SetBool("isWalking", false);
            return;
        }
        direction = player.transform.position.x - transform.position.x;
        if (health.isKnockedBack)
        {
            return;
        }

        if (!health.isDead)
        {
            if (direction > 0)
            {
                enemyDirection = transform.right;
                enemySprite.flipX = true;
                hitBoxRight = true;
            }
            else
            {
                enemyDirection = -transform.right;
                enemySprite.flipX = false;
                hitBoxRight = false;

            }
            //rbEnemy.linearVelocity = enemyDirection * speed;

            Vector2 rayDirection = hitBoxRight ? Vector2.right : Vector2.left;
            Vector2 rayOrigin = (Vector2)transform.position + Vector2.up * 1.0f + rayDirection * 0.5f;
            RaycastHit2D hit = Physics2D.Raycast(
                rayOrigin,
                rayDirection,
                attackRange
            );
            Debug.DrawRay(rayOrigin, rayDirection * attackRange, Color.red);

            if (hit.collider != null && hit.collider.CompareTag("Player") && Time.time >= nextAttackTime)
            {
                enemyAttack.OnAttack();
                nextAttackTime = Time.time + attackCooldown;
            }

            RaycastHit2D[] hits = Physics2D.RaycastAll(rayOrigin, rayDirection, detection);
            Debug.DrawRay(rayOrigin, rayDirection * detection, Color.yellow);

            foreach (RaycastHit2D detectHit in hits)
            {
                if (detectHit.collider.CompareTag("Player"))
                {
                    playerSpotted = true;
                    break;
                }
            }

            if (!playerSpotted)
            {
                rbEnemy.linearVelocity = Vector2.zero;
                anim.SetBool("isWalking", false);
                return;
            }

            rbEnemy.linearVelocity = enemyDirection * speed;
            anim.SetBool("isWalking", true);
        }
    }
    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
