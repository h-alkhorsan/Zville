using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D playerBody;
    private float MoveForceX = 3.0f;

    private PlayerAnimations playerAnimation;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();

    }


    void FixedUpdate()
    {
        Move();
        
    }
    
    // Move player on the horizontal axis

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            playerBody.velocity = new Vector2(MoveForceX, playerBody.velocity.y);
        }

        else if (h < 0 )
        {
            playerBody.velocity = new Vector2(-MoveForceX, playerBody.velocity.y);
        }

        else
        {
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
        }

        // If player not moving, remain idle

        if (playerBody.velocity.x != 0)
        {
            playerAnimation.PlayerRunAnimation(true);
        }

        else if (playerBody.velocity.x == 0)
        {
            playerAnimation.PlayerRunAnimation(false);
        }

        // Make player face in direction they are moving

        Vector3 tempScale = transform.localScale;

        if (h > 0)
        {
            tempScale.x = -1f;
        }

        else if (h < 0)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;

    }
}
