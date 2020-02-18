using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject food;
    public GameObject player;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<CharacterBehave>().holdingFood) {
            NewFood();
            player.GetComponent<CharacterBehave>().holdingFood = false;
        }
    }
    void NewFood()
    {
        Instantiate(food, transform.position, transform.rotation);
        StartCoroutine(Wait());
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
    }
}
