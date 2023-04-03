using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScale : MonoBehaviour
{
    [SerializeField]private float xMaxScale;
    private float origYScale;
    private PlayerRotation playerRotation;

    private void Awake() {
        origYScale = transform.localPosition.y;
        playerRotation = transform.parent.transform.parent.GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Increase scale when player is charging
        if(Input.GetKey(KeyCode.J) && playerRotation.GetIsPlayerChargingRot()){
            if(transform.localPosition.y > xMaxScale) return;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+Time.deltaTime*5f, transform.localPosition.z);
        }

        //Decrease to normal scale after player's charge runs out
        else if(transform.localPosition.y > origYScale && Mathf.Abs(playerRotation.GetChargedRotSpeed())<12){
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-Time.deltaTime*5f, transform.localPosition.z);
        }
    }
}
