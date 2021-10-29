using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timeCounter;
    public float startTimer;

    private void Start()
    {
        startTimer = Time.time;
    }

    public void Update()
    {
        float t = Time.time - startTimer;
        string minutes = ((int) t / 60).ToString();
        string secounds = (t % 60).ToString("f1");
        timeCounter.text = "Time: "+minutes + ":" + secounds;
    }
}
