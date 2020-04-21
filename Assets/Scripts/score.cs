using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public GameObject life1, life2, life3;
    public GameObject scoreText;
    float maxPoints = 100;
    TextMeshProUGUI currScoreText;
    TextMeshProUGUI currStrikeText;
    public string strikeVisual;
    public int strikeCount;
    // Update is called once per frame

    void Start()
    {
        audio = GetComponent<AudioSource>();
        strikeCount = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        strikeVisual = "xxx";
        currScoreText = GameObject.Find("MainCanvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        currStrikeText = GameObject.Find("MainCanvas").transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    public void calculateScore(Transform customer){
        float timeLeft = float.Parse(customer.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text);  //time left in timer
        float currentScore = float.Parse(currScoreText.text);   //current score
        currentScore = currentScore + (maxPoints * timeLeft);
        audio.PlayOneShot(clip2, .15f);
        int intScore = (int) currentScore;
        currScoreText.text = intScore.ToString();
    }

    public void addStrike() {
        if (strikeVisual != "") {
            strikeVisual = strikeVisual.Remove(strikeVisual.Length - 1, 1);
        }
        currStrikeText.text = strikeVisual;
        strikeCount--;
        audio.PlayOneShot(clip1, 1f);
        switch (strikeCount)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 2:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 1:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(true);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;

        }
    }

    public bool isGameOver(){
        //Debug.Log(strikeCount);
        if(strikeCount <= 0){
            return true;
        }

        return false;
    }
    
}
