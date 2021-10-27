using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class StupidGroundEnemyMovement : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float sidewaysMovementStrength;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float aggroRange;
    [SerializeField] private int changeDirectionChance;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private int jumpCoolDownUpperRange;
    [SerializeField] private int jumpCoolDownLowerRange;



    private const float groundCheckRadius = 0f;
    private Vector3 groundCheckCoordinateOffset = new Vector3(0f, -.5f, 0f);
    
    private float direction = 1f;
    private bool jumpOnCoolDown;

    private Random random = new Random();
    private Rigidbody2D rigidbody2D;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    
    
    void FixedUpdate()
    {
        if (!jumpOnCoolDown)
        {
            if (CheckIfGrounded())
            {
                if (DistanceCheckToTarget())
                {
                    // Aggressive targeted movement.
                    if (player.transform.position.x > transform.position.x)
                    {
                        direction = 1;
                    }
                    else
                    {
                        direction = -1;
                    }
                }
                else
                {
                    // Stupid random movement.
                    if (random.Next(0, 100) < changeDirectionChance)
                    {
                        // Change direction.
                        direction = direction * -1;
                    }
                }

                jumpOnCoolDown = true;
                StartCoroutine(JumpCooldown());
                rigidbody2D.velocity = new Vector2(0f, 0f);
                rigidbody2D.AddForce(new Vector2(sidewaysMovementStrength * direction, jumpStrength));
            }
        }
    }


    
    bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(transform.position + groundCheckCoordinateOffset, groundCheckRadius, groundLayerMask);
    }
    
    
    
    IEnumerator JumpCooldown() 
    {
        yield return new WaitForSeconds(random.Next(jumpCoolDownLowerRange, jumpCoolDownUpperRange));
        jumpOnCoolDown = false;
    }
    
    
    // SudoCode
    // 20% chance to change direction.
    // If jumping into a wall change direction.
    // Only move when jumping.
    // If the player is withing a specific range:
    //    - Increase jump frequency and speed.
    //    - Jump towards the player.

    bool DistanceCheckToTarget()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= aggroRange;
    }
}
