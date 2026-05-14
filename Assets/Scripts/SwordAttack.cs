using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage = 1;

    public GameObject attackHitbox;
    public float hitboxOffsetX = 0.9f;
    public float activeTime = 0.15f;

    private Animator anim;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        attackHitbox.SetActive(false);
        anim = GetComponent<Animator>();
    }

    public void OnAttack()
    {
        StopAllCoroutines();
        
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("attacks");
        Vector3 hitboxPosition = attackHitbox.transform.localPosition;

        if (playerMovement.hitBoxRight)
        {
            hitboxPosition.x = Mathf.Abs(hitboxOffsetX);
        }
        else
        {
            hitboxPosition.x = -Mathf.Abs(hitboxOffsetX);
        }

        attackHitbox.transform.localPosition = hitboxPosition;

        Debug.Log("Hitbox X: " + attackHitbox.transform.localPosition.x);

        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(activeTime);

        attackHitbox.SetActive(false);
    }
}
