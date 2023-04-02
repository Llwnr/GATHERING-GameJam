using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SayPlayerName : ActionNode
{
    protected override void OnStart() {
        Debug.Log(GameObject.FindWithTag("Player").name);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
