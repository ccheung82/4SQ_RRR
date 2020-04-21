using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadStartScreen", 5);
    }

    public void loadStartScreen()
    {
        SceneManager.LoadScene(1);
    }
}
