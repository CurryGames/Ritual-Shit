using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class Resource
{
    public float value, modifier, tick, particleCounter;
    public Text tex, tickText;
    //public Button resourceButton;
    public ParticleSystem particles;
    public bool playingParticles;

    public void ResourceUpdate()
    {
        if(playingParticles)
        {
            particles.Emit(50);
            particleCounter += Time.deltaTime;
            if (particleCounter >= particles.duration)
            {
                particleCounter = 0;
                //particles.Pause();
                playingParticles = false;
                
            }
        }

        tex.text = value.ToString();
        
    }
}


public class ResourcesManager : MonoBehaviour {

    public Resource food, water, health;
    public int consume;
    public bool coolDown, coolUp;
    public float initCoolDownTimer;
    public float coolDownTimer;
    public float maxCoolUp;
    public float timer, tickTimer;
    public Animator foodAnim, waterAnim, healthAnim;
    public Slider coolDownBar;
    VignetteAndChromaticAberration chromatic_Vignette;

    // Use this for initialization
    void Start () 
    {
        food.value = water.value = health.value = 20;
        food.tick = water.tick = health.tick = 1;
        chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
        chromatic_Vignette.enabled = false;
        timer = 0;
        consume = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
        food.ResourceUpdate();
        water.ResourceUpdate();
        health.ResourceUpdate();
/*
        if ((timer += Time.deltaTime) >= 5)
        {
            food.value -= consume * food.modifier;
            water.value -= consume * water.modifier;
            health.value -= consume * health.modifier;

            timer = 0;
        }
        */

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

        if(coolUp)
        {
            coolDownTimer += Time.deltaTime;
            coolDownBar.value = coolDownTimer / maxCoolUp;
            if (coolDownTimer >= maxCoolUp)
            {
                coolDownTimer = initCoolDownTimer;
                coolUp = false;
                /*food.resourceButton.enabled = false;
                water.resourceButton.enabled = false;
                health.resourceButton.enabled = false;*/
                //chromatic_Vignette.enabled = false;
            }
            
        }

        //cuando esta en modo super ritual
        if (coolDown)
        {
            
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer <= 0)
            {
                coolDownTimer = 0;
                coolDown = false;
                coolUp = true;
                /*food.resourceButton.enabled = false;
                water.resourceButton.enabled = false;
                health.resourceButton.enabled = false;*/
                chromatic_Vignette.enabled = false;
            }
            coolDownBar.value = coolDownTimer / initCoolDownTimer;
            chromatic_Vignette.chromaticAberration = Mathf.PingPong(Time.time*20, 200);
        }

        
    }

    public void AddFood()
    {
        food.value += 1;
        if (!food.playingParticles)
        {
            food.playingParticles = true;
        }
    }

    public void AddWater()
    {
        water.value += 1;
        if(!water.playingParticles)
        {
            water.playingParticles = true;
        }
    }

    public void AddHealth()
    {
        health.value += 1;
        if (!health.playingParticles)
        {
            health.playingParticles = true;
        }
    }

    public void Ritual()
    {
        if(!coolDown && !coolUp)
        {
            food.value += 20;
            coolDown = true;
            /*food.resourceButton.enabled = true;
            water.resourceButton.enabled = true;
            health.resourceButton.enabled = true;*/
            chromatic_Vignette.enabled = true;
        }
        
    }

}
