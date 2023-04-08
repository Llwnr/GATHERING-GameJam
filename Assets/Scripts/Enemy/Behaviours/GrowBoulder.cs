using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GrowBoulder : ActionNode
{
    public GameObject boulder;
    public float maxScale;

    private GameObject referencedBoulder;

    private Transform myTransform;
    private Vector3 targetPos;
    
    protected override void OnStart() {
        myTransform = context.transform;
        myTransform.GetComponent<Animator>().Play("Idle");
        
        
        //Make a boulder
        if(referencedBoulder == null){
            referencedBoulder = GameObject.Instantiate(boulder, new Vector3(0,0,-3), Quaternion.identity);
            referencedBoulder.transform.SetParent(myTransform, false);
            blackboard.myBoulder = referencedBoulder;
        }else{
            //Reset boulder local scale
            referencedBoulder.SetActive(true);
            referencedBoulder.transform.localScale = new Vector3(1,1,1);
        }
        //Disable particle for now
        referencedBoulder.transform.GetChild(1).gameObject.SetActive(false);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Look at target
        targetPos = GameObject.FindWithTag("Player").transform.position;
        Quaternion lookAtTarget = Quaternion.LookRotation(targetPos - myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, lookAtTarget, Time.fixedDeltaTime*5f);
        //Slowly grow the boulder
        referencedBoulder.transform.localScale += new Vector3(1f,0.3f,0.5f)*(Time.fixedDeltaTime*3f);
        if(referencedBoulder.transform.localScale.x < maxScale){
            return State.Running;
        }
        
        return State.Success;
    }
}
