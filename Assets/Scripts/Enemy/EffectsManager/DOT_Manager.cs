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

    private void Awake() {
        burningEffectParticles = myBurningParticleParent.GetComponentsInChildren<ParticleSystem>();
        ResetBurnTimer();
    }

    public void SetEnemyBurning(){
        isBurning = true;
    }

    private void Update() {
        if(isBurning){
            currBurnTimer -= Time.deltaTime;
            //Show enemy as burning
            SetEmission(true);
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
            isBurning = false;
            Debug.Log("Damage enemy");
            GetComponent<IDamagable>().DealDamage(3);
            ResetBurnTimer();
        }
    }

    void ResetBurnTimer(){
        currBurnTimer = maxBurnTimer;
        SetEmission(false);
    }
}
