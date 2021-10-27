using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMeny : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject UIPause;

    private GameObject UiResume;
    // Update is called once per frame

    void Update()
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

    void Resume()
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
}
