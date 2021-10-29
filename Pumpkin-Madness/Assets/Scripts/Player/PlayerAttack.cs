using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int weaponDamage = 0;
    [SerializeField] private float MaxThrowDistance;
    [SerializeField] private float ThrowSpeed;
    [SerializeField] private float rotationSpeed;
    
    private bool weaponReturning;
    public bool weaponThrown = false;
    private Vector3 weaponTargetPosition;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(weaponDamage);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (weaponThrown && weaponReturning)
            {
                Debug.Log("Weapon returned!+");
                transform.position = transform.parent.position;
                weaponThrown = false;
                weaponReturning = false;
            }
        }
    }
    
    
    
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
        
        if (weaponThrown)
        {
            ThrowWeapon();
        }
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


    
    void ThrowWeapon()
    {
        if (Vector3.Distance(transform.position, transform.parent.position) < MaxThrowDistance && !weaponReturning && transform.position != weaponTargetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, weaponTargetPosition, ThrowSpeed);
        }
        else
        {
            weaponReturning = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, ThrowSpeed);
            if (transform.position == transform.parent.position)
            {
                weaponThrown = false;
                weaponReturning = false;
            }
        }
    }
}