using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BallMove : MonoBehaviour
{
    
    Rigidbody2D rigidBall; //Physics engine call
    public float fullSpeed; //Ball fullSpeed box
    public float JumpForce; //Jump strength
    public int MaxJumpCount; //Jump count

    private bool isJumpBlocked = false;
    private float jumpBlockTime = 2f; // 입력 차단 시간 (초)
    void Awake()
    {
        rigidBall = GetComponent<Rigidbody2D>(); //  Find and return
    }


    void Update()
    {
        
        if (Input.GetButtonDown("Jump") && !isJumpBlocked) // Button space
        {
            StartCoroutine(BlockJumpInput());


            for (int i=0; i < MaxJumpCount; i++) // Jump count limit
            {
                rigidBall.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); // Apply jump
            }
            
           

        }   


       
        if (Input.GetButtonUp("Horizontal")) // Button <- -> 
        {
            rigidBall.linearVelocity = new Vector2(rigidBall.linearVelocity.normalized.x * 0.5f, rigidBall.linearVelocity.y); // Horizontal deceleration
        }
    }



    void FixedUpdate() // Rigidbody2D call 60 times per second
    {
        
        float h = Input.GetAxisRaw("Horizontal"); // Horizontal move

        rigidBall.AddForce(Vector2.right * h, ForceMode2D.Impulse); // Horizontal move speed

        
        if (rigidBall.linearVelocity.x > fullSpeed) // Full Horizontal move speed limits
            rigidBall.linearVelocity = new Vector2(fullSpeed, rigidBall.linearVelocity.y); 
        else if (rigidBall.linearVelocity.x < fullSpeed * (-1)) 
            rigidBall.linearVelocity = new Vector2(fullSpeed * (-1), rigidBall.linearVelocity.y); 

    }

    IEnumerator BlockJumpInput()
    {
        isJumpBlocked = true;
        yield return new WaitForSeconds(jumpBlockTime);
        isJumpBlocked = false;
    }
}
