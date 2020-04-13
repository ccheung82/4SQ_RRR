using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public Animator transition;
    [SerializeField] public float transitionTime = 1f;

    // Update is called once per frame
    public void loadStart()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void loadInstructions()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void loadLevelSelect()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void loadEasy()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void loadMedium()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void loadHard()
    {
        StartCoroutine(LoadLevel(5));
    }

    public void loadGameOver()
    {
        StartCoroutine(LoadLevel(6));
    }

    public void loadSettings()
    {
        Debug.Log("IMPLEMENT SETTINGS SCREEN");
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
