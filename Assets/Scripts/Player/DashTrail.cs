using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private PlayerDash playerDash;

    private void Awake() {
        trailRenderer = GetComponent<TrailRenderer>();
        playerDash = GetComponent<PlayerDash>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateTrailOnDash();
    }

    void ActivateTrailOnDash(){
        if(!playerDash.GetIsPlayerDashing()){
            trailRenderer.emitting = false;
            return;
        }

        trailRenderer.emitting = true;
    }
}
