using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Resource
{
    public bool coolDown;
    public float initCoolDownTimer;
    public float coolDownTimer;
    public float value, modifier, tick;
    public Text tex, tickText;
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
    public float timer, tickTimer;
    public Animator foodAnim, waterAnim, healthAnim;

    // Use this for initialization
    void Start () 
    {
        food.value = water.value = health.value = 100;
        food.tick = water.tick = health.tick = 1;
        timer = 0;
        consume = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
        food.ResourceUpdate();
        water.ResourceUpdate();
        health.ResourceUpdate();

        if ((timer += Time.deltaTime) >= 5)
        {
            food.value -= consume * food.modifier;
            water.value -= consume * water.modifier;
            health.value -= consume * health.modifier;

            timer = 0;
        }

        if ((tickTimer += Time.deltaTime) >= 2)
        {
            food.value += food.tick;
            water.value += water.tick;
            health.value += health.tick;

            food.tickText.text = "+ " + food.tick.ToString();
            water.tickText.text = "+ " + water.tick.ToString();
            health.tickText.text = "+ " + health.tick.ToString();

            foodAnim.SetTrigger("show_tick");
            waterAnim.SetTrigger("show_tick");
            healthAnim.SetTrigger("show_tick");

            tickTimer = 0;
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
