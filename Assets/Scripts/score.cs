using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public GameObject scoreText;
    // Update is called once per frame

    void Start()
    {
        Score scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();

    }
    public void ChangeScore(Transform customer)
    {
        float timeLeft = float.Parse(customer.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text); //time left in timer
        float currentScore = float.Parse(scoreText.GetComponent<UnityEngine.UI.Text>().text); //current score
        Debug.Log(currentScore);
        currentScore = currentScore + (currentScore * timeLeft);
        Debug.Log("score after: " + currentScore);
        scoreText.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    }
}
