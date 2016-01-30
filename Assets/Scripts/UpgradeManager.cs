using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public ResourcesManager resources;
    public Text itemInfo;
    public float cost;
    public float count = 0;
    public int clickPower;
    public string itemName;
    private float baseCost;

	// Use this for initialization
	void Start () 
    {
        baseCost = cost;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //itemInfo.text = itemName + "\nPower: " + clickPower + "\nCost: " + cost;
	}

    public void PurchaseUpgrade()
    {
        if (resources.food.value >= cost)
        {
            resources.food.value -= cost;
            count += 1;
            //click.dmg += clickPower;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, (float)count));
        }
    }
}
