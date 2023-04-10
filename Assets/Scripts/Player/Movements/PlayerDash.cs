using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDash : MonoBehaviour
{
    //Dashing is divided into start dash, is dashing, dash end
    [SerializeField]private float dashSpeed;
    [SerializeField]private float maxDashSpeed;
    [SerializeField]private float dashCooldown;
    private float resetDashCooldown;
    [SerializeField]private float dashDuration;
    private float dashTimer;

    private bool isDashing = false;

    private Rigidbody rb;
    private Vector3 dashDir;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        ChangeBaseCooldown();
    }

    void ChangeBaseCooldown(){
        resetDashCooldown = dashCooldown;
    }
    void ResetCooldown(){
        dashCooldown = resetDashCooldown;
    }

    // Update is called once per frame
    void Update()
    {   
        //To implement cooldown in dash
        dashCooldown-=Time.deltaTime;
        //If player pressed dash key, start dashing
        bool dashKeyPressed = Input.GetKeyDown(KeyCode.X);
        if(dashKeyPressed && dashCooldown <= 0){
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
        float hDir = Input.GetAxisRaw("Horizontal");
        float zDir = Input.GetAxisRaw("Vertical");
        dashDir = new Vector3(hDir, 0f, zDir);
        //Then set player as dashing
        isDashing = true;
        dashTimer = dashDuration;
        //Also reset cooldown
        ResetCooldown();
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
        rb.AddForce(dir*dashSpeed, ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxDashSpeed);
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
