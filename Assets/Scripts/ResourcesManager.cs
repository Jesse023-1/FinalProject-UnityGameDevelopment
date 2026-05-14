using UnityEngine;

public class ResourcesManager : MonoBehaviour
{

    public int coins = 0;
    public int woods = 0;

    public void WoodCalculation()
    {
        int added = Random.Range(1, 4);
        woods += added;
    }

    public void CoinCalculation()
    {
        int added = Random.Range(1, 4);
        coins += added;
    }

    public void DecreaseWood(int value)
    {
        woods -= value;
    }

    public void DecreaseCoin(int value)
    {
        coins -= value;
    }

    public void ResetResources()
    {
        coins = 0;
        woods = 0;
    }
}
