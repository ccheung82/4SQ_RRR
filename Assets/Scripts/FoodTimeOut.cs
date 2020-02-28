using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script will be in every food object and will destory the food if it hasn't already been in 5 seconds

public class FoodTimeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitAndDestroy());
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("colllision detected");

        if (col.gameObject.tag == "customer")
        {
            Destroy(this.gameObject);
            //timerScript sn = gameObject.GetComponent<timerScript>();
            //sn.ResetBtn();
        }
    }
}
