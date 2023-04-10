using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowedFloor : MonoBehaviour
{
    void OnParticleCollision(GameObject other) {
        if(other.tag == "Enemy"){
            other.GetComponent<SlowDownManager>().SlowEnemyByFreeze();
        }
    }
}
