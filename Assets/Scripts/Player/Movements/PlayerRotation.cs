using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]private float maxRotateSpeed;
    [SerializeField]private float maxHoldRotateSpeed;
    private float chargedRotSpeed, rotSpeedWhenCharging;
    //To increase the forceful rotation speed when charging
    [SerializeField]private float incrSpeed, decrSpeed;
    
    private bool chargingRotation = false;
    private bool startRotation = false;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        //Check if player is charging rotation;
        CheckForHold();
        BottleneckChargedRotationSpeed();
    }

    void BottleneckChargedRotationSpeed(){
        if(chargedRotSpeed > maxRotateSpeed) chargedRotSpeed = maxRotateSpeed;
        if(chargedRotSpeed < 0){
            chargedRotSpeed = 0;
            //Player has stopped rotating
            startRotation = false;
        }
    }

    void CheckForHold(){
        KeyCode rotateKey = KeyCode.Z;
        if(Input.GetKey(rotateKey) && !startRotation){
            chargingRotation = true;
            //Increase charged rotation speed when you're pressing the charge button.
            //More charge = more rotation speed
            chargedRotSpeed += Time.deltaTime * incrSpeed;

            SlowDownChargeRotation();//Slowly reduce the rotation when charging for a drag effect
        }else{
            chargingRotation = false;
            //Reset charging rotation speed when not charging. 
            rotSpeedWhenCharging = maxHoldRotateSpeed;
        }
        if(Input.GetKeyUp(rotateKey)){
            startRotation = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageRotation();
    }

    void SlowDownChargeRotation(){
        rotSpeedWhenCharging -= Time.deltaTime * rotSpeedWhenCharging * 0.8f;
        if(rotSpeedWhenCharging < 0) rotSpeedWhenCharging = 0;
    }

    void ManageRotation(){
        if(chargingRotation){
            //Rotate object slowly and in reverse when charging
            RotateObject(-rotSpeedWhenCharging);
        }
        if(startRotation){
            //Start charged rotation 
            RotateObject(chargedRotSpeed);
            //Slowdown charged rotation
            chargedRotSpeed -= Time.deltaTime*decrSpeed;
        }
    }

    void RotateObject(float rotSpeed){
        transform.Rotate(new Vector3(0, rotSpeed, 0));
    }

    //For showing the charged value
    public float GetMaxCharge(){
        return maxRotateSpeed;
    }

    public float GetCurrentCharge(){
        return chargedRotSpeed;
    }

    public float GetChargedRotSpeed(){
        return chargedRotSpeed;
    }

    public float GetRotationSpeedInPercent(){
        return (chargedRotSpeed/maxRotateSpeed);
    }

    public bool GetIsPlayerChargingRot(){
        return chargingRotation;
    }
}
