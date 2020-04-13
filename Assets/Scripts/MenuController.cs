using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    [SerializeField] LevelLoader levLoader;

    void Start()
    {
        playButton.SetActive(true);
        settingsButton.SetActive(true);
    }

    public void PlayButtonClicked()
    {
        levLoader.loadInstructions();
    }

    public void SettingsButtonClicked()
    {
        levLoader.loadSettings();
    }
}