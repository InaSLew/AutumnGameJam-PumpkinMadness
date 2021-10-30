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
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSkin;
    public Sprite jumpingSkin;
    public AudioSource audioSource;
    public AudioSource audioSource2;


    void Update()
    {
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        
        if (Input.GetButtonDown("Jump"))
        {
            audioSource2.Play();
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
        animator.enabled = true;
        audioSource.Pause();

        float move = Convert.ToSingle(moveLeftRight);
        playerController.Move(move * Time.deltaTime, crouch, jump);
        jump = false;
        
        if ((moveLeftRight == 0f) && (grounded == true))
        {
            audioSource.Pause();
            animator.enabled = false;
            spriteRenderer.sprite = defaultSkin;
        }

        if (grounded != true)
        {
            
            audioSource.Pause();
            animator.enabled = false;
            spriteRenderer.sprite = jumpingSkin;
        }

        else if ((moveLeftRight != 0f) && (grounded == true))
        {
            audioSource.Play();
            animator.enabled = true;
        }
    }
}