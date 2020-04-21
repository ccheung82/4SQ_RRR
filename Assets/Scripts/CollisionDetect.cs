using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetect : MonoBehaviour
{
    
    AudioSource audio;
    public AudioClip colSuccess;
    public AudioClip colFail;
    public AudioClip colThree;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col){
        col.gameObject.GetComponentInChildren<Animator>();
        //Debug.Log("food tag " + this.gameObject.tag);
        //Debug.Log("col tag " + col.gameObject.tag);

        if (this.gameObject.tag == col.gameObject.tag){  //reset timer on correct hit
            col.gameObject.transform.GetChild(0).GetChild(3).GetComponent<timerScript>().resetTimer();
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().calculateScore(col.gameObject.transform);

            if (col.gameObject.GetComponent<CustomerScript>().fedTimes <3){
            col.gameObject.GetComponent<CustomerScript>().incSize();
                audio.PlayOneShot(colSuccess, .2f);
            //correct food eating animation trigger
            col.gameObject.GetComponentInChildren<Animator>().ResetTrigger("isEating");
            col.gameObject.GetComponentInChildren<Animator>().SetTrigger("isEating");
            }
            col.gameObject.GetComponent<CustomerScript>().incFed();

            //generate next customer
            if(col.gameObject.GetComponent<CustomerScript>().fedTimes >=3){

                audio.PlayOneShot(colThree, .15f);
                GameObject.FindWithTag("Player").GetComponent<CharacterBehave>().replaceCustomer(col.gameObject);
            }

        }else{
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().addStrike();
            audio.PlayOneShot(colFail, .2f);
            //incorrect food animation trigger
            col.gameObject.GetComponentInChildren<Animator>().ResetTrigger("isIncorrect");
            col.gameObject.GetComponentInChildren<Animator>().SetTrigger("isIncorrect");
        }
       
       Destroy(this.gameObject);    //delete food on collision
    }
}
