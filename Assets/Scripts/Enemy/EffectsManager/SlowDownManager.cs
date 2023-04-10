using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownManager : MonoBehaviour
{
    [Header("Slow Effect")]
    private bool isFreezing = false;
    [SerializeField]private float maxSlowTimer;
    [SerializeField]private float currSlowTimer;
    [SerializeField]private float slowDownFactor;
    // Start is called before the first frame update
    void Start()
    {
        ResetFreezeTimer();
    }

    public void SlowEnemyByFreeze(){
        isFreezing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFreezing){
            currSlowTimer -= Time.deltaTime;
            //Slow down self
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x*slowDownFactor, rb.velocity.y, rb.velocity.z*0.8f);
        }
    }

    private void LateUpdate() {
        if(currSlowTimer < 0){
            ResetFreezeTimer();
        }
    }

    void ResetFreezeTimer(){
        currSlowTimer = maxSlowTimer;
        isFreezing = false;
    }
}
