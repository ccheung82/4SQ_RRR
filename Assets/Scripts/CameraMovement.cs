using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
 public float Speed = 10.0f;

    // Vector3 right = new Vector3(0, 90, 0);
    // Vector3 left = new Vector3(0, -90, 0);
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.AngleAxis(90, transform.up) * transform.rotation;
            //transform.Rotate(right * Time.deltaTime * Speed);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.AngleAxis(-90, transform.up) * transform.rotation;
            //transform.Rotate(left * Time.deltaTime * Speed);

        }

        //transform.rotation = vector;
        //transform.position = Vector3.Lerp(transform.position, currentPos, Speed * Time.deltaTime);

    }
}
