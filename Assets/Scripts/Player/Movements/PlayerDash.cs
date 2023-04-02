using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDash : MonoBehaviour
{
    //Dashing is divided into start dash, is dashing, dash end
    [SerializeField]private float dashSpeed;
    [SerializeField]private float dashDuration;
    private float dashTimer;

    private bool isDashing = false;

    private Rigidbody rb;
    private Vector3 dashDir;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player pressed dash key, start dashing
        bool dashKeyPressed = Input.GetKeyDown(KeyCode.K);
        if(dashKeyPressed){
            StartDash();
        }
    }

    private void FixedUpdate() {
        //Manage when to dash and how long
        HandleDash();
    }

    void StartDash(){
        //Stop player from moving in other directions when dashing by disabling its movement script
        SetActiveMovement(false);

        //Store the dash direction
        float hDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        dashDir = new Vector3(hDir, 0f, zDir);
        //Then set player as dashing
        isDashing = true;
        dashTimer = dashDuration;
    }

    void HandleDash(){
        if(!isDashing) return;
        //Make player dash
        Dash(dashDir);

        //Reduce dash timer
        dashTimer-=Time.deltaTime;
        if(dashTimer < 0){
            ExitDash();
        }

        
    }

    void Dash(Vector3 dir){
        dir = dir.normalized;
        Vector3 newPos = transform.position + (dir*dashSpeed*Time.fixedDeltaTime); 
        rb.MovePosition(newPos);
    }

    void ExitDash(){
        isDashing = false;
        SetActiveMovement(true);
    }

    void SetActiveMovement(bool value){
        GetComponent<PlayerMovement>().enabled = value;
    }

    //For other components to activate such as dash trail
    public bool GetIsPlayerDashing(){
        return isDashing;
    }
}
