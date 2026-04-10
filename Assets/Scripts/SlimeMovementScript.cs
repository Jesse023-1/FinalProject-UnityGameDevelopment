using UnityEngine;

public class SlimeMovementScript : MonoBehaviour
{

    GameObject player;

    Vector2 slimePosition;

    private Rigidbody2D rbSlime;
    private SpriteRenderer slimeSprite;

    private float speed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        rbSlime = GetComponent<Rigidbody2D>();
        slimeSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void FixedUpdate()
    {
        float direction = player.transform.position.x - transform.position.x;
        if (direction > 0)
        {
            rbSlime.linearVelocity = transform.right * speed;
            slimeSprite.flipX = false;
        }
        else
        {
            rbSlime.linearVelocity = -transform.right * speed;
            slimeSprite.flipX = true;
        }
    }
}
