using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform leftBorder;
    public Transform rightBorder;
    public Rigidbody2D rb;
    public GroundDetector groundDetector;

    public bool isLeftDirection=true;
    
    public float speed;

    void Update()
    {
        if(groundDetector.isGrounded)
            if(isLeftDirection)
            {
                rb.velocity = Vector2.left*speed;
                if(transform.position.x<leftBorder.position.x)
                    isLeftDirection=!isLeftDirection;
            } 
            else
            {
                rb.velocity = Vector2.right*speed;
                if(transform.position.x>rightBorder.position.x)
                    isLeftDirection=!isLeftDirection;
            }
    }
}
