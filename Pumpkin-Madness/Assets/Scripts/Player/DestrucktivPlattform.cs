using System;
using UnityEngine;

public class DestrucktivPlattform : MonoBehaviour
{
    private const float CoolDown = 4f;
    private bool destroyPlatform;
    
    private float startTime =5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(DisablePlatform) ,CoolDown);
            destroyPlatform = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            destroyPlatform = false;
            
            
        }
        
    }

    private void EnablePlatform()
    {
        gameObject.SetActive(true);
    }

    // private void Update()
    // {
    //     if (currenttime==startTime)
    //     {
    //         Debug.Log("hello2");
    //         DisablePlatform();
    //     }
    //     else if (currenttime>5)
    //     {
    //         currenttime = 0;
    //     }
    //     else if (currenttime<5)
    //     {
    //         Debug.Log("hello1");
    //         currenttime+= 1 *Time.deltaTime;
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //         Invoke(nameof(DisablePlatform), CoolDown);
    // }
    //
    private void DisablePlatform()
    {
        if (destroyPlatform = true)
        {
            gameObject.SetActive(false);
            Invoke(nameof(EnablePlatform), CoolDown);
            destroyPlatform = false;
            
        }
        
    }
}
