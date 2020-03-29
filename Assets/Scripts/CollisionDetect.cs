using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void OnCollisionEnter(Collision col){

        Destroy(this.gameObject);    //delete food on collision

        // Debug.Log("food tag " + this.gameObject.tag);
        // Debug.Log("col tag " + col.gameObject.tag);

        if(this.gameObject.tag == col.gameObject.tag){
            Debug.Log("the boi");
        }
       

    }
}
