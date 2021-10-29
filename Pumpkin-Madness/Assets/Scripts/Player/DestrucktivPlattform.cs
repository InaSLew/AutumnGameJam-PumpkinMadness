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

    private void DisablePlatform()
    {
        if (destroyPlatform)
        {
            Debug.Log(destroyPlatform);
            gameObject.SetActive(false);
            Invoke(nameof(EnablePlatform), CoolDown);
            destroyPlatform = false;
        }
        
    }
}
