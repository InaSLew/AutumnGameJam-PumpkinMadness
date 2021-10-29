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
    public Animator animator;

    void Update()
    {
        
        animator = GetComponent<Animator>();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.enabled = false;
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

        bool grounded = playerController.m_Grounded;
        animator.enabled = false;
        float move = Convert.ToSingle(moveLeftRight);
        playerController.Move(move * Time.deltaTime, crouch, jump);
        jump = false;
        
        if ((moveLeftRight == 0f) && (grounded == true))
        {
            animator.enabled = true;
        }
    }
}