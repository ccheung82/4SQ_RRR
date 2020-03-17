using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script will be in every food object and will destory the food if it hasn't already been in 5 seconds
public class FoodTimeOut : MonoBehaviour
{
    public bool holding = true;
    // public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject theScript = GameObject.Find("timerScript");
        // timerScript tScript = theScript.GetComponent<timerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holding == false)
        {
            Debug.Log("I should be destroying");
            StartCoroutine(WaitAndDestroy());
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "customer")
        {
            GameObject theScript = GameObject.Find("timerController");
            timerScript tScript = theScript.GetComponent<timerScript>();

            Debug.Log("colllision detected");
            Destroy(this.gameObject);
            tScript.resetTimer();
            //timerScript sn = gameObject.GetComponent<timerScript>();
            //sn.ResetBtn();
        }
    }
}
