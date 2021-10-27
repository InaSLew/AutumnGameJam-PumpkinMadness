using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    public float walkSpeed = 50f;
    float moveLeftRight = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        moveLeftRight = Input.GetAxisRaw("Horizontal") * walkSpeed;
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
    }

    void FixedUpdate()
    {
        playerController.Move(moveLeftRight *Time.deltaTime, crouch, jump);
        jump = false;
    }
}
