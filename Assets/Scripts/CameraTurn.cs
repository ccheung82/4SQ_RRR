﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{

    /* PLACE SCRIPT ON PLAYER, then set as many animals to serve in the player's Unity inspector, then
     drag each individual animal in with the starting animal to look at being element 0 and adding the
     others counter clockwise*/
    public GameObject[] objs;   //Create list of Game Objects to obtain position of for rotation
    int currentObj = 0; //Starting object to look at is 0
    private float rotSpeed = 350.0f;    //Rotation Speed of camera attached to game object
    Quaternion Rot;
    public bool canThrow;




    void Start(){
        canThrow = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        CharacterBehave charClass = GameObject.Find("Player").GetComponent<CharacterBehave>() as CharacterBehave;   //instantiate for cross script use

        //turn left
        if ((Input.GetKeyDown(KeyCode.A)) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            canThrow = false;
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
            canThrow = false;
            //Sets current obj to look at
            if (currentObj != 0)
            {
                currentObj--;
            }
            else
            {
                currentObj = objs.Length - 1;
            }

        }


        //Determines where to look
        Vector3 lookAtGoal = objs[currentObj].transform.position;


        //Determines where to look at from the player's POV
        Vector3 direction = lookAtGoal - this.transform.position;

        
        //Sets how to rotate
        Rot = Quaternion.LookRotation(direction, Vector3.up);

        //Rotates the player by checking what the rotation of the player is every frame and increments it close to the intended rotation
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Rot, Time.deltaTime * rotSpeed);

        //rotates the food along with the player
        charClass.food.transform.rotation = Quaternion.RotateTowards(charClass.food.transform.rotation, Rot, Time.deltaTime * rotSpeed);
        
        //stops player from throwing between turns
        float angle = 10;
        if(Vector3.Angle(this.transform.forward, objs[currentObj].transform.position - this.transform.position) < angle) {
            canThrow = true;
        }

    }

    //getter for currentObj index
    public int get_curr_obj(){
        return this.currentObj;
    }

}

