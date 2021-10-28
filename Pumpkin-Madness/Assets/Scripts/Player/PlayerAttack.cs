using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private int weaponDamage = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        // Vector3 mousePos = Input.mousePosition;
        //
        // mousePos.z = 13;
        // Vector3 worldPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        //
        // transform.right = worldPosition - transform.position;

        // FollowTargetWithRotation(worldPosition, 0, 1);


        // transform.Rotate(Vector3.forward);






    }
    // Make a knife follow the mouse.
    // Limit it to a specified distance away from the player after which it wont go further.
}
