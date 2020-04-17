using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetect : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        col.gameObject.GetComponentInChildren<Animator>();
        //Debug.Log("food tag " + this.gameObject.tag);
        //Debug.Log("col tag " + col.gameObject.tag);

        if (this.gameObject.tag == col.gameObject.tag){  //reset timer on correct hit
            col.gameObject.transform.GetChild(0).GetChild(3).GetComponent<timerScript>().resetTimer();
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().calculateScore(col.gameObject.transform);

            if (col.gameObject.GetComponent<CustomerScript>().fedTimes <3){
            col.gameObject.GetComponent<CustomerScript>().incSize();
            col.gameObject.GetComponentInChildren<Animator>().ResetTrigger("isEating");
            col.gameObject.GetComponentInChildren<Animator>().SetTrigger("isEating");
            }
            col.gameObject.GetComponent<CustomerScript>().incFed();

            //generate next customer
            if(col.gameObject.GetComponent<CustomerScript>().fedTimes >=3){
                GameObject.FindWithTag("Player").GetComponent<CharacterBehave>().replaceCustomer(col.gameObject);
            }

        }else{
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().addStrike();
        }
       
       Destroy(this.gameObject);    //delete food on collision
    }
}
