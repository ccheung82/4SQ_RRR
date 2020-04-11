using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneLoader : MonoBehaviour
{

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

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene(){
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelSelect() {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(5);
    }
    public void EasyLevel() {
        SceneManager.LoadScene(2);
    }
    public void MediumLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void HardLevel()
    {
        SceneManager.LoadScene(4);
    }
}

