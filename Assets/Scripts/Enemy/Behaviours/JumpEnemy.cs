using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class JumpEnemy : ActionNode
{
    public float jumpForce;
    public float maxJumpForce;
    public float dashForce;

    private Transform target;

    private Transform myTransform;
    private Rigidbody rb;
    protected override void OnStart() {
        myTransform = context.transform;
        target = GameObject.FindWithTag("Player").transform;
        rb = myTransform.GetComponent<Rigidbody>();
        Vector3 dir = (target.position - myTransform.position).normalized;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        rb.AddForce(dir * dashForce);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Limit jump force
        if(rb.velocity.y > maxJumpForce){
            rb.velocity = new Vector3(rb.velocity.x, maxJumpForce, rb.velocity.z);
        }
        //When player starts falling down, go to next step
        if(rb.velocity.y < -0.5f){
            return State.Success;
        }
        //When target is right below, go to next state(Dash down)
        float yDist = myTransform.position.y - target.position.y;
        float dist = Vector3.Distance(target.position, myTransform.position);
        if(yDist > 4 && dist < 5f){
            Debug.Log("Player is right under");
            return State.Success;
        }

        return State.Running;
    }
}
