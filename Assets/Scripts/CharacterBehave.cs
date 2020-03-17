using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehave : MonoBehaviour
{

    private GameObject food;
    public GameObject spawner;
    public GameObject playerCam;
    public GameObject nextFood;
    public GameObject[] spawnees;
    private FoodTimeOut foodTimeOut;
    //Renderer color;

    // GameObject newObj;
    // newObj = new Type("name");
    // For destroying objects- make a list that can have max 3 components? 

    public float foodDistance = 0.5f;
    public float throwForce = 2000f;
    public bool holdingFood = true;
    public bool startFood = true;
    public int level;
    private int randomInt1;
    private int randomInt2;


    int i = 0;

    // Start is called before the first frame update
    void Start(){
        GenRandom();
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
                food.GetComponent<FoodTimeOut>().holding = false;
                holdingFood = false;
            }
            //if (Input.GetKeyDown(KeyCode.DownArrow)) {
            //    Destroy(food);
            //}
        }
        else{
            if (Input.GetKeyUp(KeyCode.UpArrow)){
                
                // Debug.Log("i: "+ i);
                // if (i < (colors.Length - 1)) {
                //     i++;
                // }
                // else {
                //     i = 0;
                // }
                holdingFood = true;
                GenRandom();
            }
        }
    }

    GameObject GenRandom(){
        bool exists = GameObject.FindWithTag("food");
        randomInt1 = Random.Range(0, level);
        randomInt2 = Random.Range(0, level);

        
        if(exists){
            
            //Destroy(GameObject.FindWithTag("food"));

            food = nextFood;
            food.tag = "food";
            nextFood = Instantiate(spawnees[randomInt1], nextFood.transform.position, nextFood.transform.rotation);
            nextFood.tag = "nextFood";

            return food;
        }else{
            food = Instantiate(spawnees[randomInt1],spawner.transform.position, spawner.transform.rotation);
            food.tag = "food";
            nextFood = Instantiate(spawnees[randomInt2],nextFood.transform.position, nextFood.transform.rotation);
            nextFood.tag = "nextFood";
            return food;
        }

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
