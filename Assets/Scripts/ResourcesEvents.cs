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
    public Text eventText;
    public string[] enventString = new string[4];

	// Use this for initialization
	void Start () {
        CheckCurrentDayEvent();
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
    
            CheckCurrentDayEvent();
        }
	}

    void CheckCurrentDayEvent()
    {
        resourcesManager.food.modifier = 1;
        resourcesManager.water.modifier = 1;
        resourcesManager.health.modifier = 1;

        if (currentDayEvent[currentDay] == 0)
        {
            eventType = EventType.FOODEVENT;
            resourcesManager.food.modifier = 2;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[0];
        }
        else if (currentDayEvent[currentDay] == 1)
        {
            eventType = EventType.WATEREVENT;
            resourcesManager.water.modifier = 2;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[1];
        }
        else if (currentDayEvent[currentDay] == 2)
        {
            eventType = EventType.HEALTHEVENT;
            resourcesManager.health.modifier = 2;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[2];
        }
        else if(currentDayEvent[currentDay] == 3)
        {
            eventType = EventType.ALLEVENT;
            resourcesManager.food.modifier = 2;
            resourcesManager.water.modifier = 2;
            resourcesManager.health.modifier = 2;
            eventText.text = "Dia " + day.ToString() + "\n" + enventString[3];
        }
    }
}
