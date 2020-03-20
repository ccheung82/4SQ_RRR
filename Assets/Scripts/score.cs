using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    public void ChangeScore(Transform customer)
    {
        float timeLeft = float.Parse(customer.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text); //time left in timer
        float currentScore = float.Parse(scoreText.GetComponent<UnityEngine.UI.Text>().text); //current score
        Debug.Log(currentScore);
        currentScore = currentScore + (currentScore * timeLeft);
        Debug.Log("score after: " + currentScore);
        scoreText.text = currentScore.ToString();
    }
}
