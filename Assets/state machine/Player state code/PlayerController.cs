using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]Rigidbody2D body;
    public delegate void Behaviour(int speed);
    public PlayerBehaviour playerBehaviour;
    public bool isOnGround;
    public Animator animator;

    private void Start()
    {
        
    }

    private void Update()
    {
        Idle();
        walkingBehviour(KeyCode.A,-7,1);
        walkingBehviour(KeyCode.D,7,-1);
        jump();
    }


   
    void walkingBehviour(KeyCode input,int speed,int directionScale)
    {
        if(Input.GetKey(input))
        {
            playerBehaviour = new MoveBehaviour(body,animator,directionScale);
            playerBehaviour.RunBehaviour(speed, "walking");
        }
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerBehaviour = new JumpBehaviour(body,animator);
            playerBehaviour.RunBehaviour(10,"jump");
        }
        else if(!isOnGround)
        {
            animator.Play("jump");
        }
    }

    void Idle()
    {
        if(!Input.anyKey && !Input.anyKeyDown && isOnGround)
        {
            playerBehaviour = new IdleBehaviour(body, animator);
            playerBehaviour.RunBehaviour(0, "idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

}
