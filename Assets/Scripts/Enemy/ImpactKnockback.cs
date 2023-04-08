using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactKnockback : MonoBehaviour
{
    public static void Knockback(Transform targetToKnockback, Vector3 dir, float impactForce){
        Rigidbody rb = targetToKnockback.GetComponent<Rigidbody>();
        rb.velocity *= 0.2f;
        rb.AddForce(dir.normalized*impactForce*10f, ForceMode.Force);
    }
}
