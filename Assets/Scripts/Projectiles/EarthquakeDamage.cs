using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeDamage : MonoBehaviour, IDealDamage
{

    private void OnEnable() {
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf(){
        yield return new WaitForSeconds(0.5f);
        transform.parent.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            DamageTarget(12, other.transform);
        }
    }

    public void DamageTarget(float dmgAmt, Transform target){
        target.GetComponent<IDamagable>().DealDamage(dmgAmt);
    }
}
