using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn1 : MonoBehaviour
{

    /* PLACE SCRIPT ON PLAYER, then set as many animals to serve in the player's Unity inspector, then
     drag each individual animal in with the starting animal to look at being element 0 and adding the
     others counter clockwise*/

    //Create list of Game Objects to obtain position of for rotation
    public GameObject[] objs;

    //Starting object to look at is 0
    int currentObj = 0;

    //Rotation Speed of camera attached to game object
    private float rotSpeed = 350.0f;
    public GameObject spawner;
    public GameObject foodPos;
    Quaternion Rot;

    float timeCount = 0.0f;


    private void Start()
    {
        Debug.Log(objs.Length);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //turn left
        if ((Input.GetKeyDown(KeyCode.A)) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

            if (currentObj != objs.Length - 1)
            {
                currentObj++;
                //Debug.Log(currentObj);
            }
            else
            {
                currentObj = 0;
                //Debug.Log(currentObj);
            }

        }

        //turn right
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            //Sets current obj to look at
            if (currentObj != 0)
            {
                currentObj--;
                //Debug.Log(currentObj);
            }
            else
            {
                currentObj = objs.Length - 1;
                //Debug.Log(currentObj);
            }

        }


        //Determines where to look
        Vector3 lookAtGoal = objs[currentObj].transform.position;


        //Determines where to look at from the player's POV
        Vector3 direction = lookAtGoal - this.transform.position;

        
        //Sets how to rotate
        Rot = Quaternion.LookRotation(direction, Vector3.up);

        //Debug.Log(Rot);

        //Debug.Log(currentObj);
        
        //Debug.Log("Rotating");


        //Rotates the player by checking what the rotation of the player is every frame and increments it close to the intended rotation
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Rot, Time.deltaTime * rotSpeed);

        //objs[currentObj]

    }


}
