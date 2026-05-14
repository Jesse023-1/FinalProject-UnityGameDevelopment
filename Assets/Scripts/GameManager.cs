using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int wood = 0;
    public int coins = 0;

    public int playerMaxHealth = 3;
    public int playerCurrentHealth = 3;
    public int playerDamage = 1;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerHealth(int health)
    {
        playerCurrentHealth = health;
    }

    public void ResetPlayerHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void UpgradeWeapon(int amount)
    {
        playerDamage += amount;
    }

    public void UpgradeHealth(int amount)
    {
        playerMaxHealth += amount;
    }
}
