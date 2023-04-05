using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class JumpEnemy : ActionNode
{
    public float jumpForce;
    public float dashForce;

    private Transform target;

    private Transform myTransform;
    private Rigidbody rb;
    protected override void OnStart() {
        myTransform = context.transform;
        target = GameObject.FindWithTag("Player").transform;
        rb = myTransform.GetComponent<Rigidbody>();
        Vector3 dir = (target.position - myTransform.position).normalized;
        rb.AddForce(new Vector3(dir.x, jumpForce, dir.z), ForceMode.Impulse);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //When player starts falling down, go to next step
        if(rb.velocity.y < -0.2f){
            return State.Success;
        }
        //When target is right below, go to next state(Dash down)
        float dist = Vector3.Distance(target.position, myTransform.position);
        if(dist < 3 && myTransform.position.y>3f){
            Debug.Log("Player is right under");
            return State.Success;
        }

        return State.Running;
    }
}
