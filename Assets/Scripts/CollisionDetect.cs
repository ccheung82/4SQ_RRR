using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Destroy(GameObject.FindWithTag("food"));    //delete food on collision
    }
}
