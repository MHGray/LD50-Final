using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private SceneController highlander;
    private Scene currentScene;

    private void Awake()
    {
        //if(highlander != null)
        //{
        //    Destroy(this);
        //    return;
        //}
        //highlander = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
