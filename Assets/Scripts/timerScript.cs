﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    [SerializeField] Text uiText;
    [SerializeField] float mainTimer;
    [SerializeField] Image timerIcon;

    float timer; //timer 
    bool canCount = true; //should the timer decrease
    bool doOnce = false; 

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
            timerIcon.fillAmount = timer / mainTimer; // updates the images fill value
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.0";
            timer = 0.0f;
            GameOver();
        }
    }

    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void GameOver()
    {
        //Load a new scene
    }
}
