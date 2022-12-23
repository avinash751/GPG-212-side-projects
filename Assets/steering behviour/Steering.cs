using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Steering : MonoBehaviour
{
    [SerializeField] Follower follower;
    [SerializeField] float steeringSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float StoppingDistance;

     Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        MoveToFollower();
    }


    void MoveToFollower()
    {
        var (direction, normalisedDirection) = GetDirectionOfATarget();
        rb.velocity += direction * steeringSpeed;
        TruncateVelocity(rb.velocity.magnitude>0.5f ? maxSpeed:0);
        StopMovingWhenYouReachTarget(StoppingDistance);
    }

    (Vector3 direction,Vector3 normalized) GetDirectionOfATarget()
    {
        var Direction = follower.transform.position - transform.position;
        var NormalisedDirection = Direction.normalized;
        return (Direction, NormalisedDirection);
    }

    void TruncateVelocity(float maxSpeed)
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void StopMovingWhenYouReachTarget(float stoppingDistance)
    {
        var DistanceFromTarget = Vector3.Distance(follower.transform.position, transform.position);

        if(DistanceFromTarget <= stoppingDistance)
        {
            rb.velocity = Vector3.zero;
        }
    }


    

}
