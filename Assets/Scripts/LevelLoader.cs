using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public Animator transition;
    private int levelToLoad;

    public void loadSplash()
    {
        levelToLoad = 0;
        transition.SetTrigger("Start");
    }

    public void loadStart()
    {
        levelToLoad = 1;
        transition.SetTrigger("Start");
    }

    public void loadInstructions()
    {
        levelToLoad = 2;
        transition.SetTrigger("Start");
    }

    public void loadLevelSelect()
    {
        levelToLoad = 3;
        transition.SetTrigger("Start");
    }

    public void loadEasy()
    {
        levelToLoad = 4;
        transition.SetTrigger("Start");
    }

    public void loadMedium()
    {
        levelToLoad = 5;
        transition.SetTrigger("Start");
    }

    public void loadHard()
    {
        levelToLoad = 6;
        transition.SetTrigger("Start");
    }

    public void loadGameOver()
    {
        levelToLoad = 7;
        transition.SetTrigger("Start");
    }

    public void loadCredits()
    {
        levelToLoad = 8;
        transition.SetTrigger("Start");
        Debug.Log("IMPLEMENT CREDITS SCREEN");
    }

    public void onTransitionComplete()
    {
        //load scene
        SceneManager.LoadScene(levelToLoad);
    }
}
