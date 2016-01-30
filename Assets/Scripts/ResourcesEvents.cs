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
    private int penalitation;
    public int basePenalty;
    public Text eventText;
    public string[] enventString = new string[4];

	// Use this for initialization
	void Start () {
        //CheckCurrentDayEvent();
    }
	
	// Update is called once per frame
	void Update () {
        dayTimer += Time.deltaTime;
        if(dayTimer >= dayMaxTimer)
        {
            currentDay++;
            day++;
            if (currentDay >= currentDayEvent.Length) currentDay = 0;
            dayTimer = 0;
            penalitation  = basePenalty + Mathf.FloorToInt(Mathf.Pow(1.115f, (float)penalitation));
            CheckCurrentDayEvent();
        }
	}

    void CheckCurrentDayEvent()
    {
        /*resourcesManager.food.modifier = 1;
        resourcesManager.water.modifier = 1;
        resourcesManager.health.modifier = 1;*/

        if (currentDayEvent[currentDay] == 0)
        {
            eventType = EventType.FOODEVENT;
            resourcesManager.food.value -= penalitation;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[0];
        }
        else if (currentDayEvent[currentDay] == 1)
        {
            eventType = EventType.WATEREVENT;
            resourcesManager.water.value -= penalitation;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[1];
        }
        else if (currentDayEvent[currentDay] == 2)
        {
            eventType = EventType.HEALTHEVENT;
            resourcesManager.health.value -= penalitation;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[2];
        }
        else if(currentDayEvent[currentDay] == 3)
        {
            eventType = EventType.ALLEVENT;
            resourcesManager.food.value -= penalitation;
            resourcesManager.water.value -= penalitation;
            resourcesManager.health.value -= penalitation;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[3];
        }
    }
}
