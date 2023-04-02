using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class DashAtDir : ActionNode
{
    public float dashForce;
    public float maxDashDuration;

    private float dashDuration;
    private Transform myTransform;
    private Vector3 dirToMoveTo;
    protected override void OnStart() {
        myTransform = context.transform;
        dirToMoveTo = GameObject.FindWithTag("Player").transform.position - myTransform.position;
        dirToMoveTo = dirToMoveTo.normalized;

        dashDuration = maxDashDuration;
    }

    protected override void OnStop() {
        myTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    protected override State OnUpdate() {
        dashDuration -= Time.fixedDeltaTime;
        myTransform.GetComponent<Rigidbody>().AddForce(dirToMoveTo * dashForce, ForceMode.Force);

        if(dashDuration > 0){
            return State.Running;
        }
        return State.Success;
    }
}
