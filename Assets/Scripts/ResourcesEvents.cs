using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesEvents : MonoBehaviour {

    public enum EventType { FOODEVENT, WATEREVENT, HEALTHEVENT, ALLEVENT }
    EventType eventType;
    public ResourcesManager resourcesManager;
    public int[] currentDayEvent = new int[4];
    int currentDay, day = 1;
    public float dayTimer, dayMaxTimer;
    private int penalitation = 9;
    public int basePenalty;
    public Text eventText;
    public string[] enventString = new string[4];
    public Slider daySlider;
    public Text pFoodText, pWaterText, pHealthText;
    private PenalitationAnimation penalFood, penalWater, penalHealth;
    public AudioManager _audioManager;
    public ShakeCamera shake;

    // Use this for initialization
    void Awake () {
        //CheckCurrentDayEvent();
        penalFood = pFoodText.gameObject.GetComponent<PenalitationAnimation>();
        penalWater = pWaterText.gameObject.GetComponent<PenalitationAnimation>();
        penalHealth = pHealthText.gameObject.GetComponent<PenalitationAnimation>();
    }
	
	// Update is called once per frame
	void Update () {
        dayTimer += Time.deltaTime;
        daySlider.value = dayTimer / dayMaxTimer;
        if(dayTimer >= dayMaxTimer)
        {
            currentDay++;
            day++;
            if (currentDay >= currentDayEvent.Length) currentDay = 0;
            dayTimer = 0;
            penalitation  += penalitation/2;
            CheckCurrentDayEvent();
        }
	}

    void CheckCurrentDayEvent()
    {
        /*resourcesManager.food.modifier = 1;
        resourcesManager.water.modifier = 1;
        resourcesManager.health.modifier = 1;*/

        _audioManager.Play(_audioManager.curse, _audioManager.eventos, 1);
        shake.startShake = true;
        shake.shakingForce = 0.5f;
        shake.shakeDecay = 0.02f;

        if (currentDayEvent[currentDay] == 0)
        {
            eventType = EventType.FOODEVENT;
            resourcesManager.food.value -= penalitation;
            eventText.text = "Day " + day.ToString() + "\n" + enventString[0];
            pFoodText.text = "-" + penalitation.ToString();
            penalFood.animActive = true;
        }
        else if (currentDayEvent[currentDay] == 1)
        {
            eventType = EventType.WATEREVENT;
            resourcesManager.water.value -= penalitation;
            eventText.text = "Day " + day.ToString() + "\n" + enventString[1];
            pWaterText.text = "-" + penalitation.ToString();
            penalWater.animActive = true;
        }
        else if (currentDayEvent[currentDay] == 2)
        {
            eventType = EventType.HEALTHEVENT;
            resourcesManager.health.value -= penalitation;
            eventText.text = "Day " + day.ToString() + "\n" + enventString[2];
            pHealthText.text = "-" + penalitation.ToString();
            penalHealth.animActive = true;
        }
        else if(currentDayEvent[currentDay] == 3)
        {
            eventType = EventType.ALLEVENT;
            resourcesManager.food.value -= penalitation;
            resourcesManager.water.value -= penalitation;
            resourcesManager.health.value -= penalitation;
            eventText.text = "Day " + day.ToString() + "\n" + enventString[3];
            pFoodText.text = "-" + penalitation.ToString();
            penalFood.animActive = true;
            pWaterText.text = "-" + penalitation.ToString();
            penalWater.animActive = true;
            pHealthText.text = "-" + penalitation.ToString();
            penalHealth.animActive = true;

        }
    }
}
