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
        myTransform.GetComponent<Animator>().Play("Shake");
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        
        blackboard.myBoulder.transform.localScale -= new Vector3(1f, 0.3f, 0.7f) * Time.fixedDeltaTime*2f;
        if(blackboard.myBoulder.transform.localScale.x < 1){
            blackboard.myBoulder.SetActive(false);
            return State.Success;
        }
        
        return State.Running;
    }
}
