using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    [SerializeField] Text uiText;
    [SerializeField] float mainTimer;
    [SerializeField] Image timerIcon;

    float timer; //timer 
    bool canCount = true; //should the timer decrease
    bool doOnce = false; 
    public bool resetBool = false;

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount) //timer is active and enabled
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
            timerIcon.fillAmount = timer / mainTimer; // updates the images fill value
        }

        else if (timer <= 0.0f && !doOnce) //timer is dead
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.0";
            timer = 0.0f;
            GameOver();
        }

        if(resetBool) {
            resetTimer();
            resetBool = false;
        }
    }

    public void resetTimer() {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "customer")
        {
            resetTimer();
        }
    }

    void GameOver()
    {
        //Load a new scene
    }
}
