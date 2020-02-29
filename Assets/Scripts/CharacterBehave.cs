using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehave : MonoBehaviour
{

    public GameObject food;
    public GameObject spawner;
    public GameObject playerCam;
    public GameObject nextFood;
    public Material[] colors;

    //Renderer color;

    // GameObject newObj;
    // newObj = new Type("name");
    // For destroying objects- make a list that can have max 3 components? 

    public float foodDistance = 0.5f;
    public float throwForce = 2000f;
    public bool holdingFood = true;
    public bool startFood = true;

    int i = 0;

    // Start is called before the first frame update
    void Start(){
        food.GetComponent<Rigidbody>().useGravity = false;
        //color = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update(){

        spawner.transform.position = playerCam.transform.position + playerCam.transform.forward * foodDistance;
        //food.transform.position = spawner.transform.position + spawner.transform.forward * foodDistance;
        nextFood.transform.position = playerCam.transform.position + playerCam.transform.forward * foodDistance - playerCam.transform.up * 0.3f;

        if (holdingFood){
            food.transform.position = spawner.transform.position + spawner.transform.forward * foodDistance;
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                food.GetComponent<Rigidbody>().useGravity = true;
                food.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * throwForce);
                holdingFood = false;
            }
            //if (Input.GetKeyDown(KeyCode.DownArrow)) {
            //    Destroy(food);
            //}
        }
        else{
            if (Input.GetKeyUp(KeyCode.UpArrow)){
                
                Debug.Log("i: "+ i);
                if (i < (colors.Length - 1)) {
                    i++;
                }
                else {
                    i = 0;
                }
               
                holdingFood = true;
                NewFood();
                nextFood.GetComponent<Renderer>().material = colors[i];
                //UpdateNextFood();
            }
        }
    }

    void NewFood()
    {
        Instantiate(food, spawner.transform.position, spawner.transform.rotation);
        if (i < colors.Length - 1)
            food.GetComponent<Renderer>().material = colors[i];
        else
            food.GetComponent<Renderer>().material = colors[colors.Length-1];
    }
    void UpdateNextFood() {
        nextFood.GetComponent<Renderer>().material = colors[i];
    }
}
