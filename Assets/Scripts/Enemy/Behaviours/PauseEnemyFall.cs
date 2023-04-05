using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class PauseEnemyFall : ActionNode
{
    private Transform myTransform;
    public float maxWaitDuration;
    private float waitDuration;
    protected override void OnStart() {
        myTransform = context.transform;
        waitDuration = maxWaitDuration;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Make enemy stuck for few duration so that player can have time to react
        waitDuration -= Time.fixedDeltaTime;
        myTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if(waitDuration > 0) return State.Running;

        return State.Success;
    }
}
