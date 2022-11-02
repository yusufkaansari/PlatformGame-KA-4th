using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int activeScene;

    public void NextLevel()
    {
        Time.timeScale = 1f;
        activeScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(SceneManager.sceneCount);
        if (activeScene > SceneManager.sceneCount - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

               
    }
    public void Restart()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(activeScene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
