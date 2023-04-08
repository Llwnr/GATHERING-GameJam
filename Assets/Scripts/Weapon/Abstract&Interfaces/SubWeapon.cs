﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubWeapon : MonoBehaviour, IDealDamage
{
    protected Transform myPlayer;
    protected float dmgToDeal;
    private void OnEnable() {
        myPlayer = GameObject.FindWithTag("Player").transform;
        dmgToDeal = myPlayer.GetComponent<PlayerStats>().GetPlayerAttackStat();
    }
    //Deam damage to target
    public void DamageTarget(float dmgAmt, Transform target){
        if(target.GetComponent<IDamagable>() != null && target.tag == "Enemy"){
            target.GetComponent<IDamagable>().DealDamage(dmgToDeal);
        }
    }

    //When weapon hits, activate its various effects
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag != "Enemy") return;
        DamageTarget(dmgToDeal, other.transform);
        OnWeaponHit(other.transform);
    }

    //Define what to activate when weapon hits. Such as, shield on weapon hit, atk up, speed up etc
    public abstract void OnWeaponHit(Transform target);
}
