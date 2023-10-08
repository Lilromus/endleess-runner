using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    
    
    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float maxXVelocity = 100;
    public float distance = 0; 
    public double groundHeight = -3.5;
    public float jumpVelocity = 20;
    public bool isGrounded = false;

    //public bool isHoldingJump = false; ? nie dokonca niewiem czy warto na innych lokach 
    //public float maxHoldJumpTime=0.4f;
    //public float holdJumpTime = 0.0f; 

    public float jumpGroundThreshold = 1;

// Start is called before the first frame update
    void Start()
    {
        //yy

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs((float)(pos.y - groundHeight));
        if(isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                //isHoldingJump=true;

            }
        }

        // if(Input.GetKeyUp(KeyCode.Space))
        //{
            //isHoldingJumpu = false;
        //}
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if(!isGrounded)
        {
            /*if (isHoldingJump)
            {
                holdJumpTime += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;]=0
                }
            }*/
            pos.y += velocity.y * Time.fixedDeltaTime;
            //if(!isHoldingJump)
            //{
            velocity.y += gravity * Time.fixedDeltaTime;
            //}
            if(pos.y <= groundHeight)
            {
                pos.y = (float)groundHeight;
                isGrounded = true;
                //holdJumpTimer = 0;
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;




        if(isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            velocity.x += acceleration * Time.fixedDeltaTime;
            if(velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }

        transform.position = pos;
        
    }
}
