using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float moveSpeed;
    public float slowDownRate;
    public float destroyDelay;
    public float detectingDist;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce( new Vector3(1,0,1)*moveSpeed);
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity *= 1-slowDownRate;
    }

    private void FixedUpdate() {
        RaycastHit hit;
        Vector3 dist = new Vector3(transform.position.x, transform.position.y+detectingDist*0.7f, transform.position.z+0.7f);
        if(Physics.Raycast(dist, transform.TransformDirection(-Vector3.up), out hit, detectingDist)){
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }else{
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        Debug.DrawRay(dist, transform.TransformDirection(-Vector3.up)*detectingDist, Color.blue);
    }
}
