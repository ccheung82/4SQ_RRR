using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //mateo
    [SerializeField] public Animator transition;
    [SerializeField] public float transitionTime = 0.5f;

    // Update is called once per frame
    public void loadNextLevel() //loads the next scene by index 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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

    // screen goes from start,0 then to level select,1 then to level(2,3,4), and ends at gameover,5 then player can exit to 0 or replay level

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadStartScene() //start screen is 0
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect() { //level select is scene 1
        SceneManager.LoadScene(1);
    }

    public void GameOver() //gameover is 5
    {
        SceneManager.LoadScene(5);
    }

    public void EasyLevel() { //easy is scene 2
        SceneManager.LoadScene(2);
    }

    public void MediumLevel() //medium is scene 3
    {
        SceneManager.LoadScene(3);
    }

    public void HardLevel() //hard is scene 4
    {
        SceneManager.LoadScene(4);
    }
}

