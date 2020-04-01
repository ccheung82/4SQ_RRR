using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour{

    public int fedTimes;


    // Start is called before the first frame update
    void Start()
    {
        fedTimes = 0;
    }

    void Update(){
        if(this.gameObject.transform.GetChild(0).GetComponent<timerScript>().timesUp){
            //GameObject.FindWithTag("Player").GetComponent<GenCustomer>().replaceCustomer(this.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
