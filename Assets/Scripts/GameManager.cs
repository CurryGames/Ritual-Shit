using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState { INTRO, MENU, GAMEPLAY, END}
    public GameState state;

    public ResourcesManager resources;
    public GameObject menuCanvas, playCanvas;
    public AudioManager _audio;
    public Animator shamanAnimator, fireAnimator, panelAnimator, gameOverTextAnimator;
    public AnimationClip shamanDie;
    public bool playDead;

    public float timer, maxDayTime, introTime;
	// Use this for initialization
	void Start ()
    {
        //resources = GetComponent<ResourcesManager>();
        state = GameState.MENU;
        playCanvas.SetActive(false);
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        switch(state)
        {
            case GameState.INTRO:
                /*timer += Time.deltaTime;
                if (timer >= introTime)
                {
                    state = GameState.GAMEPLAY;
                    timer = 0;
                }*/
                break;
            case GameState.MENU:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    menuCanvas.SetActive(false);
                    playCanvas.SetActive(true);
                    state = GameState.GAMEPLAY;
                }
                    
                break;
            case GameState.GAMEPLAY:

                //timer += Time.deltaTime;


                if (resources.food.value < 0 || resources.water.value < 0 || resources.health.value < 0)
                {
                    GameOver();
                }

                break;
            case GameState.END:
                    
                if(playDead)
                {
                    timer += Time.deltaTime;
                    if(timer >= shamanDie.length)
                    {
                        shamanAnimator.Play("ShamanDead");
                        playDead = false;
                    }
                }
                if(Input.GetKeyDown(KeyCode.Return)) Application.LoadLevel(0);
                
                    break;
        }

	}

    void LaunchRandomEvent()
    {
        //TODO: define daily random events

    }

    public void GameOver()
    {
        playCanvas.SetActive(false);
        shamanAnimator.Play("ShamanDie");
        fireAnimator.Play("fireOffAnim");
        panelAnimator.Play("gameOverBackground");
        gameOverTextAnimator.Play("gameOverText02");
        playDead = true;
        state = GameState.END;
    }

    public void PlayButton()
    {
        menuCanvas.SetActive(false);
        playCanvas.SetActive(true);
        _audio.Play(_audio.curse, _audio.eventos, 1);
        state = GameState.GAMEPLAY;
    }

}
