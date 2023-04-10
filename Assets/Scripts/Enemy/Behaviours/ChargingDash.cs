using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]

public class ChargingDash : ActionNode
{
    public float chargingDuration;
    private float chargingDurationCounter;
    public float reverseDashForce;

    private Vector3 reverseDir;

    private Rigidbody rb;
    // Start is called before the first frame update
    protected override void OnStart() {
        rb = context.transform.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        reverseDir = -blackboard.moveToPosition;

        context.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        chargingDurationCounter=chargingDuration;
    }

    protected override void OnStop() {
        context.transform.GetComponent<Renderer>().material.SetColor("_Color", default);
    }

    protected override State OnUpdate() {
        chargingDurationCounter -= Time.deltaTime;
        rb.AddForce(reverseDir*reverseDashForce, ForceMode.Force);
        if(chargingDurationCounter < 0){
            return State.Success;
        }
        Debug.Log("Charging");
        return State.Running;
    }
}
