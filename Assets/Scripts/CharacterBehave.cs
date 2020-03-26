﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehave : MonoBehaviour
{

    private GameObject food;
    public GameObject spawner;
    public GameObject playerCam;
    public GameObject nextFood;
    public GameObject[] foods;
    public GameObject[] customers;

    //public float foodDistance = 0.5f;
    //public float throwForce = 2000f;
    public bool holdingFood = true;
    //public bool startFood = true;
    public int difficulty;
    private int randomInt1;
    private int randomInt2;



    // Start is called before the first frame update
    void Start(){
        holdingFood = false;        //no food till food is generated
        FirstFood();                //generates first food @ start of game

        //food.GetComponent<Rigidbody>().useGravity = false;
        //color = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update(){

        //spawner.transform.position = playerCam.transform.position + playerCam.transform.forward * foodDistance;
        //food.transform.position = spawner.transform.position + spawner.transform.forward * foodDistance;
        //nextFood.transform.position = playerCam.transform.position + playerCam.transform.forward * foodDistance - playerCam.transform.up * 0.3f;

        // if (holdingFood){
        //     food.transform.position = spawner.transform.position + spawner.transform.forward * foodDistance;
        //     if (Input.GetKeyDown(KeyCode.UpArrow)){
        //         //food.GetComponent<Rigidbody>().useGravity = true;
        //         food.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * throwForce);
        //         //food.GetComponent<FoodTimeOut>().holding = false;
        //         holdingFood = false;
        //     }
        //     //if (Input.GetKeyDown(KeyCode.DownArrow)) {
        //     //    Destroy(food);
        //     //}
        // }
        // else{
        //     if (Input.GetKeyUp(KeyCode.UpArrow)){
                
        //         // Debug.Log("i: "+ i);
        //         // if (i < (colors.Length - 1)) {
        //         //     i++;
        //         // }
        //         // else {
        //         //     i = 0;
        //         // }
        //         holdingFood = true;
        //         GenRandom();
        //     }
        // }
        
        //spawner.transform.position = playerCam.transform.position + playerCam.transform.forward * foodDistance;
        //food.transform.position = spawner.transform.position + spawner.transform.forward * foodDistance;
        
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            Destroy(GameObject.FindWithTag("food"));
            holdingFood = false;
            GenRandom();
        }

    }

    void GenRandom(){
        randomInt1 = Random.Range(0, difficulty);
        randomInt2 = Random.Range(0, difficulty);

        food = Instantiate(nextFood, spawner.transform.position, spawner.transform.rotation);
        food.tag = "food";
        holdingFood = true;

        nextFood = foods[randomInt2];
        nextFood.tag = "nextFood";
        
        // if(exists){
            
        //     //Destroy(GameObject.FindWithTag("food"));

        //     food = nextFood;
        //     food.tag = "food";
        //     nextFood = foods[randomInt1];
        //     nextFood.tag = "nextFood";

        //     return food;
        // }else{
        //     food = Instantiate(foods[randomInt1],spawner.transform.position, spawner.transform.rotation);
        //     food.tag = "food";
        //     nextFood = foods[randomInt2];
        //     nextFood.tag = "nextFood";
        //     return food;
        // }

    }
    
    //generate initialization of food/nextfood
    void FirstFood(){
        food = Instantiate(foods[Random.Range(0, difficulty)],spawner.transform.position, spawner.transform.rotation);
        food.tag = "food";

        nextFood = foods[Random.Range(0, difficulty)];
        nextFood.tag = "nextFood";

        holdingFood = true;
    }
    //    IEnumerator WaitAndDestroy()
    //{
    //    yield return new WaitForSeconds(5);
    //    Destroy(GameObject.FindWithTag("food"));
    //}


    // void NewFood()
    // {
    //     Instantiate(food, spawner.transform.position, spawner.transform.rotation);
    //     if (i < colors.Length - 1)
    //         food.GetComponent<Renderer>().material = colors[i];
    //     else
    //         food.GetComponent<Renderer>().material = colors[colors.Length-1];
    // // }
    // void UpdateNextFood() {
    //     nextFood.GetComponent<Renderer>().material = colors[i];
    // }
}
