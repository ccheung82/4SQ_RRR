using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//This script will be in every food object and will destory the food if it hasn't already been in 5 seconds
public class FoodTimeOut : MonoBehaviour
{
    public bool holding = true;
    int score = 0;
    //public TextMeshProUGUI scoreText;
    public GameObject scoreManager;
    public Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (holding == false)
        // {
        //     StartCoroutine(WaitAndDestroy());
        // }
    }

    // IEnumerator WaitAndDestroy()
    // {
    //     yield return new WaitForSeconds(5);
    //     Destroy(this.gameObject);
    // }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "customer")
        {
           //Debug.Log("colllision detected");
            GameObject theScript = GameObject.Find("timerController");
            timerScript tScript = theScript.GetComponent<timerScript>();

            //checks if food was given to correct character
            Transform foodColor = this.gameObject.transform.Find("color");
            Transform customerColor = col.gameObject.transform.Find("color");
            Debug.Log("food color is " + foodColor.tag);
            Debug.Log("customer color is " + customerColor.tag);
            if (foodColor.tag == customerColor.tag)
            {
                //score = 1;
                scoreScript.ChangeScore(col.gameObject.transform);
                Debug.Log("right color");
            }
            else
            {
                //score = -1; //do we want this or do we just want 3 lives? I think that's waht we want
                Debug.Log("wrong color");
            }
            Destroy(this.gameObject);
            tScript.resetTimer();
        }
    }
}
