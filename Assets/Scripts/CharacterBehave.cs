using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehave : MonoBehaviour
{

    public GameObject food;
    public GameObject playerCam;
    public GameObject foodSpawnPos;
    public GameObject nextFood;
    public GameObject[] foods;
    public GameObject[] customers;
    public GameObject[] positions;
    public bool holdingFood;
    public int difficulty;
    private int randomInt1;
    private int randomInt;
    private float timeTaken = 1000;
    private Dictionary<string, bool> inUse = new Dictionary<string, bool>();


    // Start is called before the first frame update
    void Start()
    {
        holdingFood = false;        //no food till food is generated

        //Debug.Log("TEST");
        switch (difficulty)
        {         //difficulty translation logic 1-3 (easy-hard), translates to # of customers (2,4,6)
            case 1:
                difficulty = 4;
                break;
            case 2:
                difficulty = 5;
                break;
            case 3:
                difficulty = 6;
                break;
            default:
                difficulty = 4;
                break;
        }

        for (int i = 0; i < customers.Length; i++) //adds all of the colors to the map
        {
            inUse.Add(foods[i].tag, false);
        }
        Debug.Log("made it here");
        for (int i = 0; i < positions.Length; i++) //instantiates # of characters needed and updates value in map
        {
            //TODO: randomize colors
            Instantiate(customers[i], positions[i].transform.position, positions[i].transform.rotation);
            inUse[customers[i].tag] = true;
        }

        FirstFood();                //generates first food @ start of game
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindWithTag("scoreSystem").GetComponent<Score>().isGameOver() == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(6);
        }

        
        if (Input.GetKeyUp(KeyCode.UpArrow) && GameObject.Find("Main Camera").GetComponent<CameraTurn>().canThrow)
        {
            CameraTurn camClass = GameObject.Find("Main Camera").GetComponent<CameraTurn>() as CameraTurn;   //instantiate for cross script use

            Vector3 movement = food.transform.rotation * Vector3.forward;
            Vector3 startpos = food.transform.GetChild(0).position; //initial food position
            Vector3 endpos = customers[camClass.get_curr_obj()].transform.position + movement * 100f;    //position of customer

            //food tossing algorithm
            float currTime = 0;

            currTime += Time.deltaTime;
            if (currTime > timeTaken)
            {
                currTime = timeTaken;
                Debug.Log("currTime");
            }

            float perc = currTime / timeTaken;
            food.transform.position = Vector3.Lerp(startpos, endpos, perc);

            holdingFood = false;    //update player status
            GenRandom();
        }

        //trash can functionality
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Destroy(this.food);
            GenRandom();
        }

        if (inUse[this.food.tag] == false) {
            Destroy(this.food);
            GenRandom();
        }

    }

    //food is nextFood and nextFood is newly generated
    void GenRandom()
    {     
        randomInt = Random.Range(0, difficulty); //generate random seeds for food selection

        bool foodVal = inUse[foods[randomInt].tag];
        if (foodVal == true)
        {

            nextFood = foods[randomInt];   //next food generated

            food = Instantiate(nextFood, foodSpawnPos.transform.position, playerCam.transform.rotation);   //create new food
            holdingFood = true; //player status update

            
        }
        else
        {
            GenRandom();
        }
    }

    void updateActiveCustomers() {

    }

    //generate initialization of food/nextfood
    void FirstFood()
    {
        int rand1 = Random.Range(0, difficulty);
        int rand2 = Random.Range(0, difficulty);

        if (inUse[foods[rand1].tag] == true && inUse[foods[rand2].tag] == true) //checks to see if the corresponding customer is in the scene
        {
            food = Instantiate(foods[rand1], foodSpawnPos.transform.position, playerCam.transform.rotation);

            nextFood = foods[rand2];

            holdingFood = true;
        }
        else
        {
            FirstFood();
        }

        Debug.Log("FIRST FOOD");
    }


    //returns current index customer to be generated and calculates the next one
    public int nextCustomerCalculation()
    {
        for (int i = 0; i < difficulty; i++)
        {
            if (inUse[customers[i].tag] == false)
                Debug.Log(inUse[customers[i].tag] + " " + customers[i]);
                return i;
        }
        return -1;
    }

    //work in progress script for replacing when time runs out    
    public void replaceCustomer(GameObject curr)
    {
        Vector3 pos = curr.transform.position;
        Quaternion rot = curr.transform.rotation;
        int index = nextCustomerCalculation();
        inUse[curr.tag] = false;
        inUse[customers[index].tag] = true;

        Destroy(curr.gameObject);
        Instantiate(customers[index], pos, rot);
        // Debug.Log("this is happening");

        for (int i = 0; i < difficulty; i++)
        {
            Debug.Log(foods[i].tag + " " + inUse[foods[i].tag]);
        }
    }
}
