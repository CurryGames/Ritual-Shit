using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PenalitationAnimation : MonoBehaviour {

    private float finalValueAlpha;
    private float timeDuration;
    private float timeCounter, timePositionCounter;
    private float initAlpha;
    private float fadeOutDuration;
    private Color colorImage;
    private Text image;
    private Vector3 position;
    private float startPostion, finalPosition;
    private RectTransform myTransfor;

    public bool animActive = false;
    private bool fadeIn = true;


    // Use this for initialization
    void Start()
    {
        image = GetComponent<Text>();
        colorImage = image.color;
        initAlpha = 0;
        finalValueAlpha = 1.0f;
        timeDuration = 1.5f;
        fadeOutDuration = 1.5f;
        myTransfor = GetComponent<RectTransform>();
        startPostion = myTransfor.localPosition.y;
        position = myTransfor.localPosition;
        finalPosition = -60;


        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (animActive)
        {
            if (fadeIn)
            {
                if (timeCounter <= timeDuration/2)
                {
                    timeCounter += Time.deltaTime;
                    float currentAlpha = (float)Easing.CubicEaseIn(timeCounter, initAlpha, (finalValueAlpha - initAlpha), timeDuration/2);

                    colorImage.a = currentAlpha;
                    image.color = colorImage;

                }
                else
                {
                    fadeIn = false;
                    timeCounter = 0;
                }
            }
            else
            {
                if (timeCounter <= fadeOutDuration)
                {
                    timeCounter += Time.deltaTime;
                    float currentAlpha = (float)Easing.CubicEaseIn(timeCounter, finalValueAlpha, (initAlpha - finalValueAlpha), fadeOutDuration);

                    colorImage.a = currentAlpha;
                    image.color = colorImage;

                }
                else animActive = false;
            }

            if (timePositionCounter <= fadeOutDuration * 2)
            {
                timePositionCounter += Time.deltaTime;
                position.y = (float)Easing.Linear(timePositionCounter, startPostion, (finalPosition - startPostion), timeDuration * 2);

                myTransfor.localPosition = position;
            }
        }
        else
        {
            IntialValue();
        }

    }

    public void ResetAnim()
    {
        timeCounter = 0;
        timePositionCounter = 0;
        colorImage.a = finalValueAlpha;
        image.color = colorImage;
        fadeIn = false;
    }

    private void IntialValue()
    {
        timeCounter = 0;
        timePositionCounter = 0;
        colorImage.a = 0;
        image.color = colorImage;
        fadeIn = true;
    }
}