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



    private bool weaponThrown = false;
    private bool throwWeapon = true;
    private Vector3 weaponTargetPosition;
    private bool weaponReturnToPlayer;


    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hej han har klickat på KNAPPEN!");
            if (!weaponThrown)
            {
                Vector3 mousePosition = Input.mousePosition;
        
                mousePosition.z = 13;
                weaponTargetPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
                weaponThrown = true;
                Debug.Log("Weapon thrown!");
            }
        }
        
        
        
        
        
        
        
        
        
        if (weaponThrown)
        {
            if (weaponReturnToPlayer)
            {
                transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.1f);
            }
            else if (weaponReturnToPlayer && transform.position == transform.parent.position)
            {
                weaponReturnToPlayer = false;
                weaponThrown = false;
            }
            else if (transform.position == weaponTargetPosition)
            {
                transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.1f);
                weaponReturnToPlayer = true;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, weaponTargetPosition, 0.1f);
            }
        }
    }
}


    // Update is called once per frame
    // void Update()
    // {
    //     // Vector3 mousePos = Input.mousePosition;
    //     //
    //     // mousePos.z = 13;
    //     // Vector3 worldPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePos);
    //     //
    //     // transform.right = worldPosition - transform.position;
    //
    //     // FollowTargetWithRotation(worldPosition, 0, 1);
    //
    //
    //     // transform.Rotate(Vector3.forward);
    //
    //
    //
    //
    //
    //
    // }
    // Make a knife follow the mouse.
    // Limit it to a specified distance away from the player after which it wont go further.
