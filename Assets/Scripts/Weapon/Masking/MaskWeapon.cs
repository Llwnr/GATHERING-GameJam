using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskWeapon : MonoBehaviour, IAfterWeaponAttached
{
    [SerializeField]private GameObject objectToMask;
    private float timer = 0f;
    private bool isAttached = false;

    private Vector3 savedPos = Vector3.zero;

    //When weapon is attacked, slowly show it as if its being generated
    public void WeaponHasBeenAttached(){
        objectToMask = transform.parent.gameObject;
        MaskObjects();
        isAttached = true;
        savedPos = transform.position;
    }
    // Start is called before the first frame update
    void MaskObjects()
    {
        objectToMask.GetComponent<MeshRenderer>().material.renderQueue = 2452;
    }

    private void Update() {
        if(isAttached){
            //Don't move the mask, but move the weapon forward for partly creation effect
            transform.position = savedPos;
            Debug.Log(transform.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAttached)
            timer -= Time.deltaTime;
        if(timer < -3){
            //After 3 seconds after attaching, remove mask
            objectToMask.GetComponent<MeshRenderer>().material.renderQueue = default;
            gameObject.SetActive(false);
        }            
    }
}
