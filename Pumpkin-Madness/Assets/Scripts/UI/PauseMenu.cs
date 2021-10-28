using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject UIPause;

    private GameObject UiResume;
    // Update is called once per frame

    [SerializeField]private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           GameISPauset();
        }
    }

    public void GameISPauset()
    {
        if (GameIsPause)
        {
            Debug.Log("Abt to Resume!");
            Resume();
        }
        else 
        {
            Pause();
        } 
    }

    public void Resume()
    {
        Debug.Log("Resume fired!");
        UIPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        UIPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    } 
    public void LoadMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("Loading menu");
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit menu");
    }
    
}
