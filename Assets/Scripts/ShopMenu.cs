using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    GameObject shopMenu;

    [SerializeField]
    Button buyArmor;
    [SerializeField]
    Button upgradeArmor;
    [SerializeField]
    Button buyWeapon;
    [SerializeField]
    Button upgradeWeapon;

    [Header("Buildings")]
    [SerializeField] private GameObject weaponSmith;
    [SerializeField] private GameObject weaponSmithUpgrade;
    [SerializeField] private GameObject armorSmith;
    [SerializeField] private GameObject armorSmithUpgrade;



    private ResourcesManager resources;
    private GameManager manager;


    void Start()
    {
        shopMenu.SetActive(false);

        resources = GameManager.Instance.GetComponent<ResourcesManager>();
        manager = GameManager.Instance.GetComponent<GameManager>();

        buyArmor.interactable = true;
        upgradeArmor.interactable = false;
        buyWeapon.interactable = true;
        upgradeWeapon.interactable = false;

    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BuyWeapon()
    {
        if (resources.coins >= 5 && resources.woods >= 5)
        {
            resources.coins -= 5;
            resources.woods -= 5;
            weaponSmith.SetActive(true);
            manager.UpgradeWeapon(1);
            buyWeapon.interactable = false;
            upgradeWeapon.interactable = true;
        }

    }

    public void UpgradeWeapon()
    {
        if (resources.coins >= 15 && resources.woods >= 15)
        {
            resources.coins -= 15;
            resources.woods -= 15;
            weaponSmithUpgrade.SetActive(true);
            manager.UpgradeWeapon(1);
            upgradeWeapon.interactable = false;
        }
    }

    public void BuyArmor()
    {
        if (resources.coins >= 5 && resources.woods >= 5)
        {
            resources.coins -= 5;
            resources.woods -= 5;
            armorSmith.SetActive(true);
            manager.UpgradeHealth(1);
            buyArmor.interactable = false;
            upgradeArmor.interactable = true;
        }
    }

    public void UpgradeArmor()
    {
        if (resources.coins >= 15 && resources.woods >= 15)
        {
            resources.coins -= 15;
            resources.woods -= 15;
            armorSmith.SetActive(true);
            manager.UpgradeHealth(1);
            upgradeArmor.interactable = false;
            
        }
    }
}
