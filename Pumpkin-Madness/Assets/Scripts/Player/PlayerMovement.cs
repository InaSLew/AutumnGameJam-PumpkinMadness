using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    public float walkSpeed = 50f;
    float moveLeftRight = 0f;
    public bool jump = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        moveLeftRight = Input.GetAxisRaw("Horizontal") * walkSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerController.Move(moveLeftRight *Time.deltaTime, false, jump);
        jump = false;
    }
}
