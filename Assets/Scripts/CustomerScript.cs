using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerScript : MonoBehaviour{

    public int fedTimes;


    // Start is called before the first frame update
    void Start()
    {
        fedTimes = 0;
    }

    void Update(){
        
    }

    public void incFed(){
        this.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text += "$";
    }
}
