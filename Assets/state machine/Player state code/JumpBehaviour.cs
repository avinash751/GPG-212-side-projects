using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : PlayerBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    
    public JumpBehaviour(Rigidbody2D RB,Animator anim)
    {
        rb = RB;
        animator = anim;
    }
    public override void RunBehaviour(int force, string animation)
    {
        Jump(force);
        animator.Play(animation);
       
    }



    void Jump(int jumpForce)
    {
        rb.velocity += Vector2.up * jumpForce;
        

    }

}
