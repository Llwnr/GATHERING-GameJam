using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class JumpEnemy : ActionNode
{
    public float jumpForce;
    public float maxJumpForce;
    public float dashForce;
    public float jumpHeight;
    private float currYHeight;

    private Transform target;

    private Transform myTransform;
    private Rigidbody rb;

    private float timer;

    protected override void OnStart() {
        myTransform = context.transform;
        target = GameObject.FindWithTag("Player").transform;
        rb = myTransform.GetComponent<Rigidbody>();
        Vector3 dir = target.position - myTransform.position;
        dir.y = 0f;
        //Stop falling before jumping for consistent jump force
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        //Add jump force
        rb.AddForce(new Vector3(0, jumpForce*10f, 0), ForceMode.Force);
        rb.AddForce(dir * dashForce, ForceMode.Force);
        
        currYHeight = myTransform.position.y;
        timer = 1f;

        SetSlowEffectActive(false);
    }

    void SetSlowEffectActive(bool value){
        myTransform.GetComponent<SlowDownManager>().enabled = value;
    }

    protected override void OnStop() {
        SetSlowEffectActive(true);
    }

    protected override State OnUpdate() {
        timer -= Time.deltaTime;
        if(timer < 0){
            return State.Success;
        }
        //Limit jump force
        if(rb.velocity.y > maxJumpForce){
            rb.velocity = new Vector3(rb.velocity.x, maxJumpForce, rb.velocity.z);
            
        }
        //When reached max height, ground pound
        if(currYHeight + jumpHeight < myTransform.position.y){
            Debug.Log("Reached max jump height");
            return State.Success;
        }
        return State.Running;
    }
}
