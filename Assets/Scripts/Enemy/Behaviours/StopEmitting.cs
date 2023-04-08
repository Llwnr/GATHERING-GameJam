using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class StopEmitting : ActionNode
{
    protected override void OnStart() {
        foreach(ParticleSystem particleSystem in blackboard.myBoulder.GetComponentsInChildren<ParticleSystem>()){
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
