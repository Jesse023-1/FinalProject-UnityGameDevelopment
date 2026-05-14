using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject playerPrefab;

    [SerializeField]
    public Transform spawnPoint;
    private float respawnDelay = 3.0f;

    AudioManager audioManager;

    [SerializeField]
    private AudioClip deathSfx;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        GameManager.Instance.ResetPlayerHealth();

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        audioManager.PlaySFX(deathSfx);
    }

    public void RespawnObject(GameObject prefab, Vector3 position, Quaternion rotation, float delay)
    {
        StartCoroutine(ObjectRespawnRoutine(prefab, position, rotation, delay));
    }

    IEnumerator ObjectRespawnRoutine(GameObject prefab, Vector3 position, Quaternion rotation, float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(prefab, position, rotation);
    }
}
