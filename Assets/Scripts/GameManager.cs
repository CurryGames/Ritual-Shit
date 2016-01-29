using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState { INTRO, GAMEPLAY, END}
    public GameState state;

    public ResourcesManager resources;

    public float timer, maxDayTime;
	// Use this for initialization
	void Start ()
    {
        resources = GetComponent<ResourcesManager>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        switch(state)
        {
            case GameState.INTRO:
                break;
            case GameState.GAMEPLAY:

                timer += Time.deltaTime;

                if (timer >= maxDayTime)
                {
                    //TODO: Change day

                    timer = 0;
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

    }

}
