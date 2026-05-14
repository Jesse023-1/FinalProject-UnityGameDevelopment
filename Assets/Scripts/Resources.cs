using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Resources : MonoBehaviour
{
    public TMPro.TMP_Text coinText;
    public TMPro.TMP_Text woodText;

    private ResourcesManager resourcesManager;

    void Start()
    {
        resourcesManager = GameManager.Instance.GetComponent<ResourcesManager>();
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = ": " + resourcesManager.coins;
        woodText.text = ": " + resourcesManager.woods;
    }
}
