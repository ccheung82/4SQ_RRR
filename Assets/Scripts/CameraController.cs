using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float turnSpeed;
    private float rotationAcceleration = 0.9f;
    public float turnspeedInital = 2f;
    void Start(){
        turnSpeed = turnspeedInital;
    }
    void Update()
    {
        //If the A key is pressed turn in the left direction at turnspeed
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, -turnSpeed, 0));
        }
            //If the D key is pressed turn in the left direction at turnspeed
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, turnSpeed, 0));
        }
        

    }
}
