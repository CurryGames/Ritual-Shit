using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public enum ResType { FOOD, WATER, HEALTH}
    public ResType type;

    public ResourcesManager resources;
    public Text resInfo;
    public float cost;
    public float count = 0;
    private float baseCost;

	// Use this for initialization
	void Start () 
    {
        baseCost = cost;
	}
	
	// Update is called once per frame
	void Update () 
    {
        resInfo.text = cost.ToString();
	}

    public void PurchaseUpgrade()
    {
        switch(type)
        {
            case ResType.FOOD:
                // Food needs health
                if (resources.health.value >= cost)
                {
                    resources.health.value -= cost;
                    count += 1;
                    cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, (float)count));
                }
                break;
            case ResType.WATER:
                // Water needs food
                if (resources.food.value >= cost)
                {
                    resources.food.value -= cost;
                    count += 1;
                    cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, (float)count));
                }
                break;
            case ResType.HEALTH:
                // Health needs water
                if (resources.water.value >= cost)
                {
                    resources.water.value -= cost;
                    count += 1;
                    cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, (float)count));
                }
                break;
        }
       
    }
}
