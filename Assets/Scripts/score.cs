using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public GameObject scoreText;
    float maxPoints = 100;
    TextMeshProUGUI currScoreText;
    TextMeshProUGUI currStrikeText;
    public string strikeVisual;
    public int strikeCount;
    // Update is called once per frame

    void Start()
    {   
        strikeCount = 3;
        strikeVisual = "xxx";
        currScoreText = GameObject.Find("MainCanvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        currStrikeText = GameObject.Find("MainCanvas").transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    public void calculateScore(Transform customer){
        float timeLeft = float.Parse(customer.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text);  //time left in timer
        float currentScore = float.Parse(currScoreText.text);   //current score
        currentScore = currentScore + (maxPoints * timeLeft);
        int intScore = (int) currentScore;
        currScoreText.text = intScore.ToString();
    }

    public void addStrike(){
        if(strikeVisual != ""){
        strikeVisual = strikeVisual.Remove(strikeVisual.Length - 1, 1); 
        }
        currStrikeText.text = strikeVisual;
        strikeCount--;
    }

    public bool isGameOver(){
        Debug.Log(strikeCount);
        if(strikeCount <= 0){
            return true;
        }

        return false;
    }
}
