using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] LevelLoader levLoader;

    public void EasyClicked()
    {
        levLoader.loadEasy();
    }

    public void MediumClicked()
    {
        levLoader.loadMedium();
    }

    public void HardClicked()
    {
        levLoader.loadHard();
    }

    public void backButtonClicked()
    {
        levLoader.loadInstructions();
    }
}
