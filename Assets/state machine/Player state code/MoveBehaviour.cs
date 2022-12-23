using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : PlayerBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public MoveBehaviour(Rigidbody2D Rb,Animator anim,int scale)
    {
        rb = Rb;
        animator = anim;
        rb.GetComponent<Transform>().localScale = new Vector3(scale,1,1);
    }

    public override void RunBehaviour(int speed,string animation)
    {
        rb.velocity = Vector2.right * speed;
        animator.Play(animation);
    }

    
  
}
