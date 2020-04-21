using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] LevelLoader levLoader;
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
                audio.Play();

            }
            else
            {
                PauseGame();
                audio.Play();
            }
        }
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Back2MainMenu()
    {
        levLoader.loadStart();
    }

    public void RestartGame()
    {
        levLoader.loadInstructions();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Pressed");
        Application.Quit();
    }

    public void CreditsClicked()
    {
        levLoader.loadCredits();
    }

    public void SettingsButton()
    {
        levLoader.loadSettings();
    }
}
