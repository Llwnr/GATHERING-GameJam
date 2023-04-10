using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShortDash : ActionNode
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

        rb.velocity = Vector3.zero;
        rb.AddForce(dirToMoveTo * dashForce, ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxDashForce);

        //Disable slowdowns
        myTransform.GetComponent<SlowDownManager>().enabled = false;
        myTransform.GetComponent<EffectReference>().EnableDashParticle();

        dashDuration = maxDashDuration;
    }

    protected override void OnStop() {
        rb.velocity *= 0.1f;
        //Enable slowdown effects
        myTransform.GetComponent<SlowDownManager>().enabled = true;
        myTransform.GetComponent<EffectReference>().DisableDashParticle();
    }

    protected override State OnUpdate() {
        dashDuration -= Time.fixedDeltaTime;

        if(dashDuration > 0){
            return State.Running;
        }
        return State.Success;
    }
}
