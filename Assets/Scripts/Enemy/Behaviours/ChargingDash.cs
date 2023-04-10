using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]

public class ChargingDash : ActionNode
{
    public float chargingDuration;
    private float chargingDurationCounter;
    public float maxSpeed;
    public float reverseDashForce;

    private Vector3 reverseDir;

    private Rigidbody rb;
    //For shake
    private Transform myTransform;
    private Vector3 origPos;
    // Start is called before the first frame update
    protected override void OnStart() {
        myTransform = context.transform;
        origPos = myTransform.position;
        rb = context.transform.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        reverseDir = -blackboard.moveToPosition;

        context.transform.GetComponent<Renderer>().material.color = Color.red;

        chargingDurationCounter=chargingDuration;
    }

    protected override void OnStop() {
        context.transform.GetComponent<Renderer>().material.color = Color.white;
    }

    protected override State OnUpdate() {
        Shake();
        chargingDurationCounter -= Time.deltaTime;
        rb.AddForce(reverseDir*reverseDashForce, ForceMode.Force);
        if(chargingDurationCounter < 0){
            return State.Success;
        }
        Debug.Log("Charging");
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        return State.Running;
    }

    void Shake(){
        myTransform.position = origPos + Random.insideUnitSphere*0.4f;
        myTransform.position = new Vector3(myTransform.position.x, origPos.y, myTransform.position.z);
    }
}
