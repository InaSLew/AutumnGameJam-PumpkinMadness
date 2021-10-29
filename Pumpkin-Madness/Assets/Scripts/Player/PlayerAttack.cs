using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // private Player player;
    // private Rigidbody2D _rigidbody2D;

    [SerializeField] private int weaponDamage = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody2D = GetComponent<Rigidbody2D>();
        // player = FindObjectOfType<Player>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(weaponDamage);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (weaponThrown && throwIteration < totalFramesToMoveAway)
            transform.position = transform.parent.position;
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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!weaponThrown)
            {
                Vector3 mousePosition = Input.mousePosition;
        
                mousePosition.z = 13;
                weaponTargetPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
                weaponThrown = true;
            }
        }
    }
}