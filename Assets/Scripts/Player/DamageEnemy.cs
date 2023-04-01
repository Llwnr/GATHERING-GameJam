using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy" && other.GetComponent<IDealDamage>() != null){
            other.GetComponent<IDealDamage>().DealDamage(5);
        }
    }
}
