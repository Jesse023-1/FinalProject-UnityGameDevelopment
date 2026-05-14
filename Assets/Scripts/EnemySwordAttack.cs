using System.Collections;
using UnityEngine;


public class EnemySwordAttack : MonoBehaviour
{
    public int damage = 1;

    public GameObject attackHitbox;
    private float hitboxOffsetX = 0.6f;
    private float activeTime = 0.15f;

    private Enemy enemyMovement;
    private EnemyHealth health;
    private Animator anim;

    void Start()
    {
        enemyMovement = GetComponent<Enemy>();
        //attackHitbox.SetActive(false);
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    public void OnAttack()
    {
        if (health.isDead) return;
        StopAllCoroutines();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (health.isDead) yield break;
        
        
        Vector3 hitboxPosition = attackHitbox.transform.localPosition;

        if (enemyMovement.hitBoxRight)
        {
            hitboxPosition.x = Mathf.Abs(hitboxOffsetX);
        }
        else
        {
            hitboxPosition.x = -Mathf.Abs(hitboxOffsetX);
        }

        attackHitbox.transform.localPosition = hitboxPosition;

        Debug.Log("Enemy Hitbox X: " + attackHitbox.transform.localPosition.x);

        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(activeTime);

        attackHitbox.SetActive(false);
    }
}
