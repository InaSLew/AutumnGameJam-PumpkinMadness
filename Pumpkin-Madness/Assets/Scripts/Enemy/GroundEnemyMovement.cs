using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Script that controls the movement of ground enemies. Enemies moves by jumping, will change direction randomly.
/// If a player is in a specified range the enemy will start jumping in the players direction at a desired increased rate.
/// </summary>
public class GroundEnemyMovement : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float sidewaysMovementStrength;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float aggroRange;
    [SerializeField] private int changeDirectionChance;
    [SerializeField] private int jumpCoolDownUpperRange;
    [SerializeField] private int jumpCoolDownLowerRange;
    [SerializeField] private int aggroJumpCoolDownReduction;

    private const float groundCheckRadius = 0f;
    private Vector3 groundCheckCoordinateOffset = new Vector3(0f, -.7f, 0f);
    
    private float direction = 1f;
    private bool jumpOnCoolDown;

    private Rigidbody2D rb;
    private LayerMask groundLayerMask;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Obstacle");
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
                    // Start the timer with a negative causing the jumps to be more frequent if a player is nearby.
                    StartCoroutine(JumpCooldown(aggroJumpCoolDownReduction));
                }
                else
                {
                    // Stupid random movement.
                    if (Random.Range(0, 100) < changeDirectionChance)
                    {
                        // Change direction.
                        direction = direction * -1;
                    }
                    StartCoroutine(JumpCooldown());
                }

                jumpOnCoolDown = true;
                rb.velocity = new Vector2(0f, 0f);
                rb.AddForce(new Vector2(sidewaysMovementStrength * direction, jumpStrength));
            }
        }
    }
    
    bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(transform.position + groundCheckCoordinateOffset, groundCheckRadius, groundLayerMask);
    }

    IEnumerator JumpCooldown(int coolDownReduction = 0) 
    {
        yield return new WaitForSeconds(Math.Max(Random.Range(jumpCoolDownLowerRange, jumpCoolDownUpperRange) - coolDownReduction, 0));
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
