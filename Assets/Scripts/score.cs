using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public GameObject scoreText;
    float maxPoints = 500;
    TextMeshProUGUI currScoreText;
    // Update is called once per frame

    void Start()
    {
        currScoreText = GameObject.Find("MainCanvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }
    public void ChangeScore(Transform customer)
    {
        float timeLeft = float.Parse(customer.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text); //time left in timer
        //Debug.Log("time left: " + timeLeft);
        float currentScore = float.Parse(currScoreText.text);//current score
        //Debug.Log("score before: " + currentScore);
        currentScore = currentScore + (maxPoints * timeLeft);
        int intScore = (int) currentScore;
        //Debug.Log("score after: " + currentScore);
        currScoreText.text = intScore.ToString();
    }
}
