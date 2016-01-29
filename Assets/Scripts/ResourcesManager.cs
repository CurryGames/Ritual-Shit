using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour {


    public int food, water, health;
    public int consume;
    public float timer;
    public Text foodText, waterText, healthText;


	// Use this for initialization
	void Start () 
    {
        food = water = health = 100;
        timer = 0;
        consume = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        foodText.text = food.ToString();
        waterText.text = water.ToString();
        healthText.text = health.ToString();

        if ((timer += Time.deltaTime) >= 1)
        {
            food -= consume;
            water -= consume;
            health -= consume;

            timer = 0;
        }
	}

    public void AddFood()
    {
        food += 1;
    }

    public void AddWater()
    {
        water += 1;
    }

    public void AddHealth()
    {
        health += 1;
    }

    public void RitualFood()
    {
        food += 20;
    }

    public void RitualWater()
    {
        water += 10;
    }

    public void RitualHealth()
    {
        health += 10;
    }
}
