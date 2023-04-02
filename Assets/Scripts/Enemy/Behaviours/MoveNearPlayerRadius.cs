using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveNearPlayerRadius : ActionNode {

    public float speed;
    public float radiusToStopAt;
    public float dashForce;

    private Transform myTransform;

    private Vector3 goalPos;
    private Vector3 dir;

    protected override void OnStart() {
        myTransform = context.transform;
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

        Vector3 newPos = myTransform.position + dir*speed*Time.fixedDeltaTime;
        myTransform.GetComponent<Rigidbody>().MovePosition(newPos);

        return State.Running;
    }

    void FindTargetPosition(){
        goalPos = GameObject.FindWithTag("Player").transform.position;
        dir = (goalPos - myTransform.position).normalized;
        blackboard.moveToPosition = dir;
    }

    void StartDash(){
        myTransform.GetComponent<TrailRenderer>().emitting = true;
        myTransform.GetComponent<Rigidbody>().AddForce(dir*dashForce, ForceMode.Impulse);
    }
}
