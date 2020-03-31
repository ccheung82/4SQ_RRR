using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public GameObject[] spawnees;
    public Transform spawnPos;
    public int level;
    int randomInt;
    // Update is called once per frame
    void Update()
    {
        bool inp = Input.GetKeyUp("space");

        if(inp){
            GenRandom();
        }   
    }

    void GenRandom(){
        bool exists = GameObject.FindWithTag("food");

        randomInt = Random.Range(0, level);
        if(exists){
            Destroy(GameObject.FindWithTag("food"));
            Instantiate(spawnees[randomInt],spawnPos.position, spawnPos.rotation);
        }else{
            Instantiate(spawnees[randomInt],spawnPos.position, spawnPos.rotation);
        }

    }
}
