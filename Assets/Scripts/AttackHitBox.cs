using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public int damage = 1;
    private Animator anim;

    AudioManager audioManager;

    [SerializeField]
    private AudioClip treecut;
    [SerializeField]
    private AudioClip enemySlice;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        damage = GameManager.Instance.playerDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioManager.PlaySFX(enemySlice);
            other.GetComponent<EnemyHealth>().TakeDamage(damage, transform.position);
        }
        if (other.CompareTag("Tree"))
        {
            audioManager.PlaySFX(treecut);
            other.GetComponent<TreeHealth>().TreeTakeDamage(damage);
        }
    }
}
