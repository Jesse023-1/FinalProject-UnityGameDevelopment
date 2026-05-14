using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    public Transform player;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(0f, 2f, -15f);
        FindPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        transform.position = player.position + offset;
    }
    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");

        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }
}

