using UnityEngine;

public class AttackerAttackHitBox : MonoBehaviour
{
    public int damage = 1;

    private Animator anim;

    AudioManager manager;

    [SerializeField]
    private AudioClip knife;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("attacks");
            manager.PlaySFX(knife);
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage, transform.position);
        }
    }
}
