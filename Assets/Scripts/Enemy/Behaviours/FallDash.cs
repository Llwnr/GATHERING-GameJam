using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class FallDash : ActionNode
{
    private Rigidbody rb;
    public float downForce;

    private float timer;
    protected override void OnStart() {
        rb = context.transform.GetComponent<Rigidbody>();
        //Make transform fall quicker
        rb.AddForce(new Vector3(0f, -downForce, 0f), ForceMode.Impulse);
        rb.velocity = new Vector3(rb.velocity.x, -0.1f, rb.velocity.z);

        timer = 0;
    }

    protected override void OnStop() {
        rb.GetComponent<TrailRenderer>().emitting = false;
    }

    protected override State OnUpdate() {
        //in case some glitch happens where the velocity is not 0 after landing
        timer += Time.fixedDeltaTime;
        if(timer > 1) return State.Success;
        
        //If object has stopped falling
        if(rb.velocity.y >= 0){
            Debug.Log("Hit wall");
            return State.Success;
        }
        
        return State.Running;
    }
}
