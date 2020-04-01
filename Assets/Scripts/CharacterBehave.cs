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
    public GameObject[] positions;
    public bool holdingFood;
    public int difficulty;
    public int nextCustomer;
    private int randomInt1;
    private int randomInt2;
    private float timeTaken = 10;
    //public Dictionary<GameObject,bool> map;



    // Start is called before the first frame update
    void Start(){

        //Debug.Log("TEST");
        switch(difficulty){         //difficulty translation logic 1-3 (easy-hard), translates to # of customers (2,4,6)
            case 1: 
                difficulty = 3;
                break;
            case 2:
                difficulty = 5;
                break;
            case 3:
                difficulty = 7;
                break;
            default:
                difficulty = 3;
                break;
        }

        //instantiate at start
        Instantiate(customers[0], positions[0].transform.position, positions[0].transform.rotation);
        Instantiate(customers[1], positions[1].transform.position, positions[1].transform.rotation);
        Instantiate(customers[2], positions[2].transform.position, positions[2].transform.rotation);
        Instantiate(customers[3], positions[3].transform.position, positions[3].transform.rotation);


        nextCustomer = difficulty - 1;
        holdingFood = false;        //no food till food is generated
        FirstFood();                //generates first food @ start of game
    }

    // Update is called once per frame
    void Update(){
        
        if(GameObject.FindWithTag("scoreSystem").GetComponent<Score>().isGameOver() == true){
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)){

            CameraTurn camClass = GameObject.Find("Main Camera").GetComponent<CameraTurn>() as CameraTurn;   //instantiate for cross script use
            
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

        //trash can functionality
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            Destroy(this.food);
            GenRandom();
        }



    }

    void GenRandom(){
        randomInt1 = Random.Range(0, difficulty);       //generate random seeds for food selection
        randomInt2 = Random.Range(0, difficulty);

        food = Instantiate(nextFood, playerCam.transform.position, playerCam.transform.rotation);   //create new food
        holdingFood = true; //player status update

        nextFood = foods[randomInt2];   //next food generated
    }
    
    //generate initialization of food/nextfood
    void FirstFood(){
        food = Instantiate(foods[Random.Range(0, difficulty)],playerCam.transform.position, playerCam.transform.rotation);

        nextFood = foods[Random.Range(0, difficulty)];

        holdingFood = true;
    }

    //returns current index customer to be generated and calculates the next one
    public int nextCustomerCalculation(){
        int currIndex = nextCustomer;
        nextCustomer++;

        if(nextCustomer == difficulty){
            nextCustomer = 0;
        }

        return currIndex;
    }
}
