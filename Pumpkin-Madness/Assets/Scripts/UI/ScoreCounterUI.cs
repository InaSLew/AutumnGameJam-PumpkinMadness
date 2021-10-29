using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreCounterUI : MonoBehaviour
{
    public static ScoreCounterUI instance;
    public double scoreKill;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score.text = scoreKill.ToString() + " Kills";
    }

    public void AddKill()
    {
        scoreKill += 0.5;
        score.text = scoreKill.ToString() + " Kills";
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     score.text= "Score:  " + scoreKill;
    // }
}
