using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : PlayerBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public IdleBehaviour(Rigidbody2D rb,Animator animator)
    {
        this.rb = rb;
        this.animator = animator;
    }
    public override void RunBehaviour(int speed, string animation)
    {
        rb.velocity = Vector3.zero * speed;
        animator.Play(animation);
    }

}
