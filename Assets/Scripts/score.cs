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
    public GameObject strikes;
    public string strikeVisual;
    public int strikeCount = 0;
    // Update is called once per frame

    void Start()
    {
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
        strikeVisual += "x";
        currStrikeText.text = strikeVisual;
        strikeCount++;
    }

    public bool isGameOver(){
        if(strikeCount == 3){
            return true;
        }

        return false;
    }
}
