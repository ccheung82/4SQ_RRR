using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public Animator transition;
    private int levelToLoad;

    public void loadStart()
    {
        levelToLoad = 0;
        transition.SetTrigger("Start");
    }

    public void loadInstructions()
    {
        levelToLoad = 1;
        transition.SetTrigger("Start");
    }

    public void loadLevelSelect()
    {
        levelToLoad = 2;
        transition.SetTrigger("Start");
    }

    public void loadEasy()
    {
        levelToLoad = 3;
        transition.SetTrigger("Start");
    }

    public void loadMedium()
    {
        levelToLoad = 4;
        transition.SetTrigger("Start");
    }

    public void loadHard()
    {
        levelToLoad = 5;
        transition.SetTrigger("Start");
    }

    public void loadGameOver()
    {
        levelToLoad = 6;
        transition.SetTrigger("Start");
    }

    public void loadSettings()
    {
        Debug.Log("IMPLEMENT SETTINGS SCREEN");
    }

    public void onTransitionComplete()
    {
        //load scene
        SceneManager.LoadScene(levelToLoad);
    }



    //IEnumerator LoadLevel(int levelIndex)
    //{
    //    //play animation
    //    transition.SetTrigger("Start");
    //    //wait
    //    yield return new WaitForSeconds(transitionTime);
    //}
}
