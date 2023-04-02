using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShrinkBoulder : ActionNode
{
    private Transform myTransform;
    
    protected override void OnStart() {
        myTransform = context.transform;
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        
        blackboard.myBoulder.transform.localScale -= Vector3.one * Time.fixedDeltaTime;
        if(blackboard.myBoulder.transform.localScale.z < 1){
            blackboard.myBoulder.SetActive(false);
            return State.Success;
        }
        
        return State.Running;
    }
}
