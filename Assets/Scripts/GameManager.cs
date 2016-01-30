using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState { INTRO, GAMEPLAY, END}
    public GameState state;

    public ResourcesManager resources;

    public float timer, maxDayTime, introTime;
	// Use this for initialization
	void Start ()
    {
        //resources = GetComponent<ResourcesManager>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        switch(state)
        {
            case GameState.INTRO:
                timer += Time.deltaTime;
                if (timer >= introTime)
                {
                    state = GameState.GAMEPLAY;
                    timer = 0;
                }
                break;
            case GameState.GAMEPLAY:

                timer += Time.deltaTime;


                if (resources.food.value == 0 || resources.water.value == 0 || resources.health.value == 0)
                {
                    GameOver();
                }

                break;
            case GameState.END:
                break;
        }

	}

    void LaunchRandomEvent()
    {
        //TODO: define daily random events

    }

    public void GameOver()
    {
        state = GameState.END;
    }

}
