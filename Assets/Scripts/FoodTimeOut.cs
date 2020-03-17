using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script will be in every food object and will destory the food if it hasn't already been in 5 seconds
public class FoodTimeOut : MonoBehaviour
{
    public bool holding = true;

    // Start is called before the first frame update
    void Start()
    {
        
       
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
            Debug.Log("colllision detected");
            Destroy(this.gameObject);
            //timerScript sn = gameObject.GetComponent<timerScript>();
            //sn.ResetBtn();
        }
    }
}
