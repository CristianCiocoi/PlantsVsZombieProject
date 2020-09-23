using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime()); 
        }
        
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene1()
    {
        Time.timeScale = 1;
        currentSceneIndex = 2;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void RestartScene2()
    {
        Time.timeScale = 1;
        currentSceneIndex = 3;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /*
    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    */

    public void QuitGame()
    {
        Application.Quit();
    }

}
