using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamage : MonoBehaviour, IDealDamage
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            DamageTarget(8, other.transform);
        }
    }

    public void DamageTarget(float dmgAmt, Transform target){
        target.GetComponent<IDamagable>().DealDamage(dmgAmt);
    }
}
