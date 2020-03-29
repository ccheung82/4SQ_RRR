using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        // Debug.Log("food tag " + this.gameObject.tag);
        // Debug.Log("col tag " + col.gameObject.tag);


        if(this.gameObject.tag == col.gameObject.tag){  //reset timer on correct hit
            col.gameObject.transform.GetChild(0).GetChild(3).GetComponent<timerScript>().resetTimer();
            GameObject.FindWithTag("scoreSystem").GetComponent<Score>().calculateScore(col.gameObject.transform);

        }else{
        }
       
       Destroy(this.gameObject);    //delete food on collision
    }
}
