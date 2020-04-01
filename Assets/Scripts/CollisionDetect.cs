using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Debug.Log("food tag " + this.gameObject.tag);
        Debug.Log("col tag " + col.gameObject.tag);


        if(this.gameObject.tag == col.gameObject.tag){  //reset timer on correct hit
            col.gameObject.transform.GetChild(0).GetChild(3).GetComponent<timerScript>().resetTimer();
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().calculateScore(col.gameObject.transform);
            col.gameObject.GetComponent<CustomerScript>().fedTimes++;

            //generate next customer
            if(col.gameObject.GetComponent<CustomerScript>().fedTimes >=3){
                Vector3 pos = col.transform.position;
                Quaternion rot = col.transform.rotation;

                int index = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehave>().nextCustomerCalculation();
                Destroy(col.gameObject);
                Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehave>().customers[index], pos, rot);
            }

        }else{
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().addStrike();
        }
       
       Destroy(this.gameObject);    //delete food on collision
    }
}
