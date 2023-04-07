using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SpawnEarthquakes : ActionNode
{
    public GameObject earthquakes;
    protected override void OnStart() {
        Transform myTransform = context.transform;
        GameObject earthquake = GameObject.Instantiate(earthquakes, myTransform.position, Quaternion.identity);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
