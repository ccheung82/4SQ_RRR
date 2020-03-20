using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        float curretScore = float.Parse(scoreText.text);
        //float newScore = float.Parse(col.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text);
        //scoreVal = scoreVal + (scoreVal * newScore);
        //curretScore = newScore;
        //make currentScore show on the Text
    }
}
