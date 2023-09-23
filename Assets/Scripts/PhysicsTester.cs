using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTester : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 forceVector = Vector2.right;
    public ForceMode2D forceMode;
    public float timerForAccelerationDebug = 1f;
    public bool stopAfterTimerReached = false;

    private float timer = 0f;

    private void Start()
    {
        timer = Time.time + timerForAccelerationDebug;
    }

    private void FixedUpdate()
    {
        if (stopAfterTimerReached && Time.time >= timer)
        {
            //GetVelocityWhenStopped();
            return;
        }
        rb.AddForce(forceVector, forceMode);

        // debug
        float b = rb.mass * rb.drag;
        float maxVelocity = forceVector.x / b;
        print($"Max Velocity: {maxVelocity}. Acceleration Time to Max Velocity: {maxVelocity / rb.drag}. Current time: {Time.time}. Current velocity: {rb.velocity}");
    }

    private void GetVelocityWhenStopped()
    {
        print($"Time when stopped: {Time.time}. Velocity when stopped: {rb.velocity}.");
    }    
}
