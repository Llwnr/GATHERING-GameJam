using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveNearPlayerRadius : ActionNode {

    public float speed;
    public float radiusToStopAt;
    public float dashForce;
    public float maxMoveSpeed;

    private Transform myTransform;
    private Rigidbody rb;

    private Vector3 goalPos;
    private Vector3 dir;

    protected override void OnStart() {
        myTransform = context.transform;
        rb = myTransform.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        FindTargetPosition();
        float distance = Mathf.Abs(Vector3.Distance(goalPos, myTransform.position));
        
        //If target is near radius then move to next step
        if(distance < radiusToStopAt){
            StartDash();
            return State.Success;
        }

        
        rb.AddForce(dir*speed, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMoveSpeed);

        return State.Running;
    }

    void FindTargetPosition(){
        goalPos = GameObject.FindWithTag("Player").transform.position;
        dir = (goalPos - myTransform.position).normalized;
        blackboard.moveToPosition = dir;
        //Look at target
        Quaternion lookAtTarget = Quaternion.LookRotation(goalPos - myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, lookAtTarget, Time.fixedDeltaTime);
    }

    void StartDash(){
        myTransform.GetComponent<TrailRenderer>().emitting = true;
        myTransform.GetComponent<Rigidbody>().AddForce(dir*dashForce, ForceMode.Impulse);
    }
}
