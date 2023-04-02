using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveNearPlayerRadius : ActionNode {
    public float speed = 12;
    public float stoppingDistance;
    public bool updateRotation = true;
    public float acceleration = 40.0f;
    public float tolerance = 5.0f;

    private float moveTimer;
    public float maxMoveTimer;

    protected override void OnStart() {
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.moveToPosition;
        context.agent.updateRotation = updateRotation;
        context.agent.acceleration = acceleration;
        //Limit for how long the enemy will try to move to a position
        moveTimer = maxMoveTimer;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        // moveTimer-=Time.deltaTime;
        // if(moveTimer < 0) return State.Success;

        // Debug.Log(context.agent.remainingDistance);

        //Stop when player is in radius
        if (context.agent.remainingDistance < tolerance) {
            Debug.Log("Player is now near my radius. Ready to aoe attack");
            return State.Success;
        }

        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Running;
    }
}
