using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class DashAtDir : ActionNode
{
    public float dashForce;
    public float maxDashForce;
    public float maxDashDuration;

    private float dashDuration;
    private Transform myTransform;
    private Vector3 dirToMoveTo;

    private Rigidbody rb;
    protected override void OnStart() {
        myTransform = context.transform;
        rb = myTransform.GetComponent<Rigidbody>();
        dirToMoveTo = GameObject.FindWithTag("Player").transform.position - myTransform.position;
        dirToMoveTo = dirToMoveTo.normalized;

        dashDuration = maxDashDuration;
    }

    protected override void OnStop() {
        rb.velocity *= 0.1f;
    }

    protected override State OnUpdate() {
        dashDuration -= Time.fixedDeltaTime;
        rb.AddForce(dirToMoveTo * dashForce, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxDashForce);

        //Enable particle
        blackboard.myBoulder.transform.GetChild(1).gameObject.SetActive(true);

        if(dashDuration > 0){
            return State.Running;
        }
        return State.Success;
    }
}
