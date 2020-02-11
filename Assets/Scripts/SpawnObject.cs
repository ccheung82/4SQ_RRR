using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject food;
    public int speed = 9;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Spawn Button pressed");
            GameObject newFood = Instantiate(food);
            newFood.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
    }
}
