using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubWeapon : MonoBehaviour, IDealDamage
{
    //Deam damage to target
    public void DamageTarget(float dmgAmt, Transform target){
        if(target.GetComponent<IDamagable>() != null && target.tag == "Enemy"){
            target.GetComponent<IDamagable>().DealDamage(dmgAmt);
        }
    }

    //When weapon hits, activate its various effects
    private void OnTriggerEnter(Collider other) {
        DamageTarget(5, other.transform);
        OnWeaponHit();
    }

    //Define what to activate when weapon hits. Such as, shield on weapon hit, atk up, speed up etc
    public abstract void OnWeaponHit();
}
