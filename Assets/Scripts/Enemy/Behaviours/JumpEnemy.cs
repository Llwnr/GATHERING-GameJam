using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class JumpEnemy : ActionNode
{
    public float jumpForce;
    public float dashForce;

    private Transform myTransform;
    private Rigidbody rb;
    protected override void OnStart() {
        myTransform = context.transform;
        rb = myTransform.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Continue moving quickly at the previous direction when jumping
        rb.MovePosition(blackboard.moveToPosition.normalized*Time.fixedDeltaTime*dashForce + myTransform.position);
        //When player starts falling down, go to next step
        if(rb.velocity.y < -0.2f){
            Debug.Log("falling");
            return State.Success;
        }

        return State.Running;
    }
}
