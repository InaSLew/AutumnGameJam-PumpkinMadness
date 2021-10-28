using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestrucktivPlattform : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Thread.Sleep(4500);
            Invoke(nameof(Test), timer);
        }
    }

    private void Test()
    {
        gameObject.SetActive(false);
    }
}
