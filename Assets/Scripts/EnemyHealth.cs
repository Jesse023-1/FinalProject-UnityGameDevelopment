using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    private Rigidbody2D rbEnemy;
    private Animator anim;

    public bool isDead = false;
    public bool isKnockedBack = false;

    private float knockBackX = 5f;


    public GameObject prefab;

    public float respawn = 20f;

    Vector3 respawnPosition;
    Quaternion respawnRotation;

    void Start()
    {
        currentHealth = maxHealth;
        rbEnemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
    }

    public void TakeDamage(int damage, Vector2 playerPos)
    {

        currentHealth -= damage;

        Debug.Log(gameObject.name + " took " + damage + " damage");
        if (currentHealth <= 0)
        {
            isDead = true;
            StartCoroutine(Death(playerPos));
        } else
        { 
            StartCoroutine(Knockback(playerPos)); 
        }
    }

    IEnumerator Death(Vector2 playerPos)
    {
        yield return StartCoroutine(Knockback(playerPos));
        anim.SetBool("isDead", isDead);

        GameManager.Instance.GetComponent<ResourcesManager>().CoinCalculation();

        rbEnemy.linearVelocity = Vector2.zero;
        rbEnemy.bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(3f);

        RespawnManager respawnManager = FindAnyObjectByType<RespawnManager>();

        if (respawnManager != null)
        {
            respawnManager.RespawnObject(prefab, respawnPosition, respawnRotation, respawn);
        }

        Destroy(gameObject);
    }

    IEnumerator Knockback(Vector2 playerPos)
    {
        isKnockedBack = true;
        yield return new WaitForSeconds(0.3f);
        
        Vector2 knockbackDirection = ((Vector2)transform.position - playerPos).normalized;

        Vector2 force = new Vector2(knockbackDirection.x * knockBackX, 5f);
        rbEnemy.AddForce(force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);
        
        isKnockedBack = false;
    }

    //void Die()
    //{

    //    Destroy(gameObject);
    //}
}
