using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    public GameObject prefab;

    public float respawn = 20f;

    void Start()
    {
        currentHealth = maxHealth;


    }

    public void TreeTakeDamage(int damage)
    {

        currentHealth -= damage;

        Debug.Log(gameObject.name + " took " + damage + " damage");
        if (currentHealth <= 0)
        {
            Chopped();
        }
    }

    private void Chopped()
    {
        GameManager.Instance.GetComponent<ResourcesManager>().WoodCalculation();

        Vector3 respawnPosition = transform.position;
        Quaternion respawnRotation = transform.rotation;

        RespawnManager respawnManager = FindAnyObjectByType<RespawnManager>();

        if (respawnManager != null)
        {
            respawnManager.RespawnObject(prefab, respawnPosition, respawnRotation, respawn);
        }


        Destroy(gameObject);
    }
}
