using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timerScript : MonoBehaviour
{
    [SerializeField] Text uiText;
    [SerializeField] float mainTimer;
    [SerializeField] Image timerIcon;

    decimal timer; //timer 
    bool canCount = true; //should the timer decrease
    bool doOnce = false; 
    public bool resetBool = false;

    void Start()
    {
        timer = (decimal)mainTimer;
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

        else if (timer <= 0 && !doOnce) //timer is dead
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0";
            timer = 0;

            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().addStrike();
        }

        if(resetBool) {
            resetTimer();
            resetBool = false;
        }
    }

    public void resetTimer() {
        timer = (decimal)mainTimer;
        canCount = true;
        doOnce = false;
    }

    // void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.tag == "customer")
    //     {
    //         Debug.Log("TIMER COLLISION");
    //         resetTimer();
    //     }
    // }
}
