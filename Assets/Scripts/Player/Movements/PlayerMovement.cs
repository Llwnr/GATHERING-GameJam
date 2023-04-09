using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed, maxSpeed;
    private float origMoveSpeed;
    private float hDir,zDir;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        origMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(hDir, 0, zDir).normalized;
        rb.AddForce(moveDir*moveSpeed);

        LimitMovespeed();
    }

    void LimitMovespeed(){
        //Player should not jump very high
        if(rb.velocity.y > 2) rb.velocity = new Vector3(rb.velocity.x, 2, rb.velocity.y);
        Vector3 clampVelocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity = new Vector3(clampVelocity.x, rb.velocity.y, clampVelocity.z);
        //Also slow down smoother
        if(hDir == 0 && zDir == 0){
            rb.velocity = new Vector3(rb.velocity.x*0.3f, rb.velocity.y, rb.velocity.z*0.3f);
        }
    }
}
