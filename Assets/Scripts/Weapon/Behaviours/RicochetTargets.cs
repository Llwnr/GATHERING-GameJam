using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RicochetTargets : MonoBehaviour
{
    [Header("Radius")]
    [SerializeField]private float range;
    private Transform nearestEnemy;
    private List<Transform> enemiesInRange = new List<Transform>();
    private List<Transform> alreadyHitEnemies = new List<Transform>();
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ricochet());
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.U)){
            StopAllCoroutines();
            alreadyHitEnemies.Clear();
            transform.localPosition = Vector3.zero;
            StartCoroutine(Ricochet());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            if(!alreadyHitEnemies.Contains(other.transform))
                alreadyHitEnemies.Add(other.transform);
        }
    }

    IEnumerator Ricochet(){
        enemiesInRange.Clear();
        
        nearestEnemy = null;
        float nearestDist = float.MaxValue;
        //Check if theres enemy in range and pick the closest one that hasn't been hit
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, transform.forward);
        for(int i=0; i<hits.Length; i++){
            if(hits[i].collider != null && hits[i].transform.tag == "Enemy"){
                //Ignore the enemies that have already been hit
                if(alreadyHitEnemies.Contains(hits[i].transform)) continue;
                //Add the enemies in range
                enemiesInRange.Add(hits[i].transform);
                float dist = Vector3.Distance(transform.position, hits[i].transform.position);
                //Find the nearest enemy
                if(dist < nearestDist){
                    nearestDist = dist;
                    nearestEnemy = hits[i].transform;
                }
            }
        }
        //Make the projectile return to socket when there's no target
        if(nearestEnemy == null){
            StartCoroutine(ReturnToOrigPos());
            yield break;
        }

        //Move projectile near targeted enemy until it hits
        float waitTime = 0.5f;//Only wait for 0.5s per target
        while(!alreadyHitEnemies.Contains(nearestEnemy)){
            waitTime -= Time.fixedDeltaTime;

            Vector3 dir = nearestEnemy.position - transform.position;
            dir = dir.normalized;
            //Manage angle
            float angle = FindAngleToLookAt(nearestEnemy, dir);
            transform.localEulerAngles = new Vector3(0, 0, -angle-90);
            //Move to target
            transform.position = transform.position+dir*Time.fixedDeltaTime*25f;
            if(waitTime > 0){
                Debug.Log("Waiting");
                yield return null;
            }
            else
                break;
        }
        StartCoroutine(Ricochet());
    }

    IEnumerator ReturnToOrigPos(){
        float distFromOrigPos = Vector3.Distance(transform.localPosition, Vector3.zero);
        Vector3 dir = -transform.localPosition.normalized;
        while(distFromOrigPos > 3f){
            distFromOrigPos = Vector3.Distance(transform.localPosition, Vector3.zero);
            //Manage angle
            float angle = FindAngleToLookAt(nearestEnemy, dir);
            transform.localEulerAngles = new Vector3(0, 0, -angle-90);

            transform.localPosition += dir*Time.fixedDeltaTime*10f;
            yield return null;
        }
        transform.localPosition = Vector3.zero;
        Debug.Log("Has returned");
    }

    //Finds the correct angle for the weapon to rotate to
    float FindAngleToLookAt(Transform nearestEnemy, Vector3 dir){
        angle = Mathf.Atan2(dir.x, dir.z)*Mathf.Rad2Deg;
        return angle;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(transform.position, range);
    }
}
