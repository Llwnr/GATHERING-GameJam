using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveToPlayer : ActionNode
{
    private Vector3 goalPos;
    private Transform transform;
    protected override void OnStart() {
        goalPos = GameObject.FindWithTag("Player").transform.position;
        blackboard.moveToPosition = goalPos;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        
        return State.Success;
    }
}
