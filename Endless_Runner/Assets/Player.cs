using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    
    
    public float gravity;
    public Vector2 velocity;
    public float groundHeight = -3;
    public float jumpVelocity = 20;
    public bool isGrounded = false;

    //public bool isHoldingJump = false; ? nie dokonca niewiem czy warto na innych lokach 
    //public float maxHoldJumpTime=0.4f;
    //public float holdJumpTime = 0.0f; 

    public float jumpGroundThreshold = 1;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
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
                    isHoldingJump = false;
                }
            }*/
            pos.y += velocity.y * Time.fixedDeltaTime;
            //if(!isHoldingJump)
            //{
            velocity.y += gravity * Time.fixedDeltaTime;
            //}
            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
                //holdJumpTimer = 0;
            }
        }

        transform.position = pos;
        
    }
}
