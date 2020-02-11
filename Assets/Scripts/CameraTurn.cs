using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    private bool spawned = false;
    private float decay;


    // Update is called once per frame
    void Update()
    {
        //The private function Reset called first to reset values changed in input function below.
        Reset();
        
        //Turn right 90 degrees
        if (Input.GetKey(KeyCode.D) && !spawned)
            {
            //Change input repetition time delay here.
            decay = 0.1f;
            spawned = true;
            //Change MIDDLE value to affect Y axis rotation.
            transform.Rotate(new Vector3(0.0f, 5.0f, 0.0f));
            }
        //Turn Left 90 Degrees
        else if (Input.GetKey(KeyCode.A) && !spawned)
            {
            //Change input repetition time delay here.
            decay = 0.1f;
            spawned = true;
            transform.Rotate(new Vector3(0.0f, -5.0f, 0.0f));
            }
    }
    

     private void Reset()
    {
    //Will only reset once Spawned is TRUE and you have any amount of delay greater than 0.
     if(spawned && decay > 0)
        {
        //sets decay less than 0.
         decay -= Time.deltaTime;
        }
     if(decay < 0)
        {
        //Resets delay to 0 and resets boolean Spawned to false.
         decay = 0;
         spawned = false;
        }
     }
  
    
}
