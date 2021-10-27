using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    public double walkSpeed = 40f;
    public double runMultiplier = 1.5f;
    double moveLeftRight = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
       
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
        moveLeftRight = Input.GetAxisRaw("Horizontal") * walkSpeed;

        if (Input.GetKeyDown("left shift") && (crouch !=true))
        {
            walkSpeed = walkSpeed * runMultiplier;
        }
        
        else if (Input.GetKeyUp("left shift"))
        {
            walkSpeed = walkSpeed / runMultiplier;
        }
    }

    void FixedUpdate()
    {

        float move = Convert.ToSingle(moveLeftRight);
        playerController.Move(move * Time.deltaTime, crouch, jump);
        jump = false;
    }
}