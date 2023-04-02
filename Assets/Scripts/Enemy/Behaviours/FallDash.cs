using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class FallDash : ActionNode
{
    private Rigidbody rb;
    public float downForce;
    protected override void OnStart() {
        rb = context.transform.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, -downForce, 0f), ForceMode.Impulse);
    }

    protected override void OnStop() {
        rb.GetComponent<TrailRenderer>().emitting = false;
    }

    protected override State OnUpdate() {
        
        //If object has stopped falling
        if(rb.velocity.y >= 0){
            Debug.Log("Hit wall");
            return State.Success;
        }
        
        return State.Running;
    }
}
