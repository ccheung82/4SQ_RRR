using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject controlsPanel;
    public GameObject settingsPanel;
    public GameObject continueButton;
    public GameObject backButton;

    void Start()
    {
        playButton.SetActive(true);
        settingsButton.SetActive(true);
    }

    public void PlayGame()
    {
        controlsPanel.SetActive(true);
        continueButton.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
    }

    public void ContinueButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButtonClicked()
    {
        settingsPanel.SetActive(false);
        continueButton.SetActive(true);
    }
    



}