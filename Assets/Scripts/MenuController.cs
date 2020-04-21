using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject creditsButton;
    [SerializeField] LevelLoader levLoader;

    void Start()
    {
        playButton.SetActive(true);
    }

    public void PlayButtonClicked()
    {
        levLoader.loadInstructions();
    }

    public void CreditsButtonClicked()
    {
        levLoader.loadCredits();
    }
}