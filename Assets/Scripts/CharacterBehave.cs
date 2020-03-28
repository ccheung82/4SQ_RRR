using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehave : MonoBehaviour
{

    public GameObject food;
    public GameObject playerCam;
    public GameObject nextFood;
    public GameObject[] foods;
    public GameObject[] customers;
    public bool holdingFood;
    public int difficulty;
    private int randomInt1;
    private int randomInt2;
    private float timeTaken = 10;



    // Start is called before the first frame update
    void Start(){

        //Debug.Log("TEST");
        switch(difficulty){         //difficulty translation logic 1-3 (easy-hard), translates to # of customers (2,4,6)
            case 1: 
                difficulty = 2;
                break;
            case 2:
                difficulty = 4;
                break;
            case 3:
                difficulty = 6;
                break;
            default:
                difficulty = 2;
                break;
        }
        holdingFood = false;        //no food till food is generated
        FirstFood();                //generates first food @ start of game
    }

    // Update is called once per frame
    void Update(){
        

        if(Input.GetKeyUp(KeyCode.UpArrow)){

            CameraTurn1 camClass = GameObject.Find("Main Camera").GetComponent<CameraTurn1>() as CameraTurn1;   //instantiate for cross script use
            
            Vector3 movement = food.transform.rotation * Vector3.forward;
            Vector3 startpos = food.transform.GetChild(0).position; //initial food position
            Vector3 endpos = customers[camClass.get_curr_obj()].transform.position + movement * 100f;    //position of customer
            
            //food tossing algorithm
            float currTime = 0;

            currTime += Time.deltaTime;
            if(currTime > timeTaken){
                currTime = timeTaken;
            }

            float perc = currTime/timeTaken;
            food.transform.position = Vector3.Lerp(startpos, endpos, perc);

            holdingFood = false;    //update player status
            GenRandom();
        }



    }

    void GenRandom(){
        randomInt1 = Random.Range(0, difficulty);       //generate random seeds for food selection
        randomInt2 = Random.Range(0, difficulty);

        food = Instantiate(nextFood, playerCam.transform.position, playerCam.transform.rotation);   //create new food
        food.tag = "food";  //set tag for deletion and access
        holdingFood = true; //player status update

        nextFood = foods[randomInt2];   //next food generated
        nextFood.tag = "nextFood";  //next food tag set
    }
    
    //generate initialization of food/nextfood
    void FirstFood(){
        food = Instantiate(foods[Random.Range(0, difficulty)],playerCam.transform.position, playerCam.transform.rotation);
        food.tag = "food";

        nextFood = foods[Random.Range(0, difficulty)];
        nextFood.tag = "nextFood";

        holdingFood = true;
    }
}
