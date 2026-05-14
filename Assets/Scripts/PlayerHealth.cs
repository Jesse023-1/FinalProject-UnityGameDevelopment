using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    private Rigidbody2D rbPlayer;
    private Animator anim;

    public bool isDead = false;
    public bool isKnockedBack = false;

    private float knockBackX = 5f;

    [SerializeField]
    private Transform respawnPoint;
    private Collider2D colPlayer;

    private RespawnManager respawnManager;

    

    void Start()
    {
        isDead = false;
        isKnockedBack = false;
        respawnManager = FindAnyObjectByType<RespawnManager>();

        maxHealth = GameManager.Instance.playerMaxHealth;
        currentHealth = GameManager.Instance.playerCurrentHealth;

        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colPlayer = GetComponent<Collider2D>();

        
    }

    public void TakeDamage(int damage, Vector2 playerPos)
    {
        if (isDead) return;

        currentHealth -= damage;
        GameManager.Instance.SetPlayerHealth(currentHealth);
        Debug.Log(gameObject.name + " took " + damage + " damage");
        if (currentHealth <= 0)
        {
            
            StartCoroutine(Death());
            return;
        }

        StartCoroutine(Knockback(playerPos));
    }

    IEnumerator Death()
    {
        isKnockedBack = false;
        //yield return new WaitForSeconds(0.3f);
        isDead = true;
        anim.SetBool("isDead", isDead);

        rbPlayer.linearVelocity = Vector2.zero;
        rbPlayer.bodyType = RigidbodyType2D.Kinematic;
        colPlayer.enabled = false;


        yield return new WaitForSeconds(3f);
        
        respawnManager.RespawnPlayer();
        Destroy(gameObject);
    }

    IEnumerator Knockback(Vector2 playerPos)
    {
        isKnockedBack = true;

        rbPlayer.linearVelocity = Vector2.zero;

        Vector2 knockbackDirection = ((Vector2)transform.position - playerPos).normalized;

        Vector2 force = new Vector2(knockbackDirection.x * knockBackX, 0.5f);

        rbPlayer.AddForce(force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);

        isKnockedBack = false;
    }
}
