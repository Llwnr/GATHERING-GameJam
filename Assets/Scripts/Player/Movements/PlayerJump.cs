using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]private float jumpForceImpulse;
    [SerializeField]private float maxJumpSpeed;
    private KeyCode jumpKey;
    private Rigidbody rb;

    [SerializeField]private LayerMask groundLayer;

    private bool isGrounded = true;
    private float jumpTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        jumpKey = KeyCode.C;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded){
            //How long has the player been in jump state
            jumpTimer += Time.deltaTime;
        }
        if(!isGrounded && jumpTimer > 0.5f){
            CheckIfGrounded();
        }
        //Jump
        if(Input.GetKeyDown(jumpKey) && isGrounded){
            isGrounded = false;
            rb.AddForce(new Vector3(0f, jumpForceImpulse, 0f), ForceMode.Impulse);
        }

        LimitJumpSpeed();
    }

    void LimitJumpSpeed(){
        //Fall faster if player released
        if(Input.GetKeyUp(jumpKey) && rb.velocity.y > 0){
            rb.AddForce(new Vector3(0,-1,0)*jumpForceImpulse*0.5f, ForceMode.Impulse);
        }
        //Limit jump force
        if(rb.velocity.y > maxJumpSpeed){
            rb.velocity = new Vector3(rb.velocity.x, maxJumpSpeed, rb.velocity.y);
        }
    }

    void CheckIfGrounded(){
        if(Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer)){
            isGrounded = true;
            jumpTimer = 0;
        }
    }
}
