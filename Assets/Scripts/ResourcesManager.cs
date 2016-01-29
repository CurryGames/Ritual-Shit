using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Resource
{
    public bool coolDown;
    public float initCoolDownTimer;
    public float coolDownTimer;
    public int value;
    public Text tex;
    public Slider coolDownBar;

    public void ResourceUpdate()
    {
        if(coolDown)
        {
            coolDownTimer -= Time.deltaTime;
            if(coolDownTimer <= 0)
            {
                coolDownTimer = initCoolDownTimer;
                coolDown = false;
            }

        }

        tex.text = value.ToString();
        coolDownBar.value = coolDownTimer / initCoolDownTimer;
    }
}


public class ResourcesManager : MonoBehaviour {

    public Resource food, water, health;
    public int consume;
    public float timer;

    // Use this for initialization
    void Start () 
    {
        food.value = water.value = health.value = 100;
        timer = 0;
        consume = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        food.ResourceUpdate();
        water.ResourceUpdate();
        health.ResourceUpdate();

        if ((timer += Time.deltaTime) >= 1)
        {
            food.value -= consume;
            water.value -= consume;
            health.value -= consume;

            timer = 0;
        }
	}

    public void AddFood()
    {
        food.value += 1;
    }

    public void AddWater()
    {
        water.value += 1;
    }

    public void AddHealth()
    {
        health.value += 1;
    }

    public void RitualFood()
    {
        if(!food.coolDown)
        {
            food.value += 20;
            food.coolDown = true;
        }
        
    }

    public void RitualWater()
    {
        if(!water.coolDown)
        {
            water.value += 10;
            water.coolDown = true;
        }
        
    }

    public void RitualHealth()
    {
        if(!health.coolDown)
        {
            health.value += 10;
            health.coolDown = true;
        }
        
    }
}
