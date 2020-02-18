using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text scoreDisplay;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = ("Score:" + score);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collider collision){
        if(collision.gameObject.tag == "Projectile"){
            score ++;
            scoreDisplay.text = ("Score" + score);
            Debug.Log(score);
        }
    }
}
