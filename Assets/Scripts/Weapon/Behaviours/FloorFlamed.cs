using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlamed : MonoBehaviour
{

    void OnParticleCollision(GameObject other) {
        if(other.tag == "Enemy"){
            other.GetComponent<DOT_Manager>().SetEnemyBurning();
        }
    }
}
