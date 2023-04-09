using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT_Manager : MonoBehaviour
{
    //FOR BURN ONLY
    [Header("Burn Effect")]
    private bool isBurning = false;//Every 1 second of continuous burn is 3 damage;
    [SerializeField]private float maxBurnTimer;
    [SerializeField]private float currBurnTimer;
    [SerializeField]private GameObject myBurningParticleParent;
    private ParticleSystem[] burningEffectParticles;

    [Header("Slow Effect")]
    private bool isFreezing = false;
    [SerializeField]private float maxSlowTimer;
    [SerializeField]private float currSlowTimer;

    private void Awake() {
        burningEffectParticles = myBurningParticleParent.GetComponentsInChildren<ParticleSystem>();
        ResetBurnTimer();
        ResetFreezeTimer();
    }

    public void SetEnemyBurning(){
        isBurning = true;
    }

    public void SlowEnemyByFreeze(){
        isFreezing = true;
    }

    private void Update() {
        if(isBurning){
            currBurnTimer -= Time.deltaTime;
            //Show enemy as burning
            SetEmission(true);
        }

        if(isFreezing){
            currSlowTimer -= Time.deltaTime;
            //Slow down self
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity *= 0.97f;
        }
    }

    void SetEmission(bool value){
        for(int i=0; i<burningEffectParticles.Length; i++){
            var emission = burningEffectParticles[i].emission;
            emission.enabled = value;
        }
    }

    private void LateUpdate() {
        //Stop burning effect when time runs out
        if(currBurnTimer < 0){
            Debug.Log("Damage enemy");
            GetComponent<IDamagable>().DealDamage(3);
            ResetBurnTimer();
        }

        if(currSlowTimer < 0){
            ResetFreezeTimer();
        }
    }

    void ResetBurnTimer(){
        currBurnTimer = maxBurnTimer;
        isBurning = false;
        SetEmission(false);
    }
    void ResetFreezeTimer(){
        currSlowTimer = maxSlowTimer;
        isFreezing = false;
    }
}
