using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (GameIsPause)
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
        Debug.Log("Resume fired!");
        UIPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        UIPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    } 
    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit menu");
    }
}
