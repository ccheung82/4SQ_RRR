using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class timerScript : MonoBehaviour
{
    [SerializeField] Text uiText;
    [SerializeField] float mainTimer;
    [SerializeField] Image timerIcon;
    public TextMeshProUGUI timesFed;

    public int difficulty;
    decimal timer; //timer 
    bool canCount = true; //should the timer decrease
    public bool timesUp = false;
    public bool resetBool = false;
    public GameObject cxTimeOut;
    //time for easy/med/hard
    public int easyTime = 10;
    public int medTime = 15;
    public int hardTime = 20;

    void Start()
    {
        //timer = (decimal)mainTimer;
        difficulty = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehave>().getDifficulty();

        if (difficulty == 4) //easy
        {
            mainTimer = easyTime;
            timer = (decimal)easyTime;
        }
        else
        if (difficulty == 5) //medium
        {
            mainTimer = medTime;
            timer = (decimal)medTime;
        }
        else
        if (difficulty == 6) //hard
        {
            mainTimer = hardTime;
            timer = (decimal)hardTime;
        }
    }

    void Update()
    {
        if (timer >= 0 && canCount) //timer is active and enabled
        {
            timer -= (decimal)Time.deltaTime;
            int rounded = (int)(Decimal.Truncate(timer));
            uiText.text = rounded.ToString();
            timerIcon.fillAmount = (float)timer / mainTimer; // updates the images fill value
        }

        else if (timer <= 0 && !timesUp) //timer is dead
        {
            canCount = false;
            timesUp = true;
            uiText.text = "0";
            timer = 0;

            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().addStrike();

            //store GameObject of parent who ran out of time
            cxTimeOut = transform.parent.parent.gameObject;
            Debug.Log(cxTimeOut.tag);
            GameObject.FindWithTag("Player").GetComponent<CharacterBehave>().replaceCustomer(cxTimeOut);
        }

        if (resetBool)
        {
            resetTimer();
            resetBool = false;
        }
    }

    public void resetTimer()
    {
        if(difficulty == 4) //easy
        {
            mainTimer = easyTime;
            timer = (decimal)easyTime;
        }
        else
        if (difficulty == 5) //medium
        {
            mainTimer = medTime;
            timer = (decimal)medTime;
        }
        else
        if (difficulty == 6) //hard
        {
            mainTimer = hardTime;
            timer = (decimal)hardTime;
        }
        canCount = true;
        timesUp = false;
    }
}