using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepSpawnEffect : MonoBehaviour, IAfterWeaponAttached
{

    public void WeaponHasBeenAttached(){
        StartCoroutine(SlowlyGenerateWeapon());
    }

    IEnumerator SlowlyGenerateWeapon(){
        //Make its position a bit backwards to make it slowly bring forward with mask for a partition creation effect
        transform.localPosition = new Vector3(0,-6,0);
        while(transform.localPosition.y < 0){
            transform.localPosition += new Vector3(0,0.05f,0);
            yield return null;
        }
        transform.localPosition = Vector3.zero;
    }


}
