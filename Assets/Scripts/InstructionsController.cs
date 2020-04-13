using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject backButton;
    [SerializeField] LevelLoader levLoader;

    void Start()
    {
        continueButton.SetActive(true);
        backButton.SetActive(true);
    }

    public void ContinueButtonClicked()
    {
        levLoader.loadLevelSelect();
    }

    public void backButtonClicked()
    {
        levLoader.loadStart();
    }
}