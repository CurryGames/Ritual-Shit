using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {


    public int food, water, health;
    public int consume;
    public float timer;


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
}
