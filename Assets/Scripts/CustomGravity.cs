using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1f;
    public static float GlobalGravity = -9.81f;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Disabling gravity");
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = gravityScale * GlobalGravity * Vector3.up;
        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
    }
}
