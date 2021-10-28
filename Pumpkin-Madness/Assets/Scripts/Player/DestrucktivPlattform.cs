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
        // if (!gameObject.activeInHierarchy)
        // {
        //     Debug.Log("listen here you lil shit");
        //     Test2();
        // }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            Invoke(nameof(Test), timer);
        }
        
    }

    private void Test()
    {
        gameObject.SetActive(false);
        Debug.Log("works");
        StartCoroutine(waitSecounds());
    }

    IEnumerator waitSecounds()
    {
        Debug.Log("platform active? " + gameObject.activeInHierarchy);
        Debug.Log("platform active? " + gameObject.activeInHierarchy);
        Debug.Log(gameObject.name);
        yield return new WaitForSeconds(4);
        gameObject.SetActive(true);
    }
}
