using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;

    [SerializeField] private int weaponDamage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(weaponDamage);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        
        mousePos.z = 13;
        Vector2 worldPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        // Debug.Log($"X = {worldPosition.x}");
        // Debug.Log($"Y = {worldPosition.y}");
        transform.position = worldPosition;
        Quaternion test = transform.rotation;
        test.z = test.z + 1;
        transform.rotation = test;







        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Vector3 mousePos = Input.mousePosition;
        //     {
        //         // Debug.Log(mousePos.x);
        //         // Debug.Log(mousePos.y);
        //         mousePos.z = 13;
        //         Vector2 worldPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        //         Debug.Log($"X = {worldPosition.x}");
        //         Debug.Log($"Y = {worldPosition.y}");
        //         transform.position = worldPosition;
        //     }
        // }
    }
    // Make a knife follow the mouse.
    // Limit it to a specified distance away from the player after which it wont go further.
}
