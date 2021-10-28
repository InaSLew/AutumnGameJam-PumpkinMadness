using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeCounter : MonoBehaviour
{
    public static TimeCounter instance;

    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;

    private bool timerGoing;

    private float elaspedTime;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        timeCounter.text = "Time: 00.00.00";
        
        timerGoing = false;
    }

    private void BeginTimer()
    {
        timerGoing = true;
        elaspedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elaspedTime += UnityEngine.Time.deltaTime;
            timePlaying=TimeSpan.FromSeconds(elaspedTime);
            string timePlayingStr = "Time:" + timePlaying.ToString("mm':' ss'.' ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }
    
}
