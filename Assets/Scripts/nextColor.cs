using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextColor : MonoBehaviour
{

    public GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Renderer>().material = foodPrefab.GetComponent<Renderer>().material;
    }
}
