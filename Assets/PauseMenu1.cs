using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool pause = false;
    public static int ran;

    public GameObject pauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        ran = Random.Range(4, 17);
        if (pause)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pause = false;
    }
    public void paunpa()
    {
        pause = true;
    }
    public void Skip()
    {
        
        SceneManager.LoadScene(ran);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Home Page");
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
