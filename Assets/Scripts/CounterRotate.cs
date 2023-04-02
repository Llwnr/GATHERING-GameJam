using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterRotate : MonoBehaviour
{
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -parent.eulerAngles.y, transform.localEulerAngles.z);

    }
}
