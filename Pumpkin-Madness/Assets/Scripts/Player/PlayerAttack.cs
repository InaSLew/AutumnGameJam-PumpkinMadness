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


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log($"should be {player.name}");
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(weaponDamage);
        }

        Debug.Log($"{other.gameObject.name} has the tag: {other.gameObject.tag}");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Weapon returned!");
            weaponThrown = false;
            throwIteration = 0;
        }
    }



    private bool weaponThrown = false;
    private bool throwWeapon = true;
    private Vector3 weaponTargetPosition;
    private bool weaponReturnToPlayer;

    public int totalFramesToMoveAway;
    private int throwIteration;

    private void FixedUpdate()
    {
        if (weaponThrown)
        {
            if (throwIteration < totalFramesToMoveAway)
            {
                transform.position = Vector3.Lerp(transform.position, weaponTargetPosition, 0.1f);
                throwIteration++;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.1f);
            }
        }


        // if (weaponThrown)
        // {
        //     if (weaponReturnToPlayer)
        //     {
        //         transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.1f);
        //     }
        //     else if (weaponReturnToPlayer && transform.position == transform.parent.position)
        //     {
        //         weaponReturnToPlayer = false;
        //         weaponThrown = false;
        //     }
        //     else if (transform.position == weaponTargetPosition)
        //     {
        //         transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.1f);
        //         weaponReturnToPlayer = true;
        //     }
        //     else
        //     {
        //         transform.position = Vector3.Lerp(transform.position, weaponTargetPosition, 0.1f);
        //     }
        // }
    }

    private void Update()
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
                Debug.Log(weaponTargetPosition);
                Debug.Log("Weapon thrown!");
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
