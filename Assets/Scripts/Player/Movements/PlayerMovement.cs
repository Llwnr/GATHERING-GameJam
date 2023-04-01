using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    private float hDir,zDir;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(hDir, 0, zDir).normalized;
        Vector3 newPos = transform.position + (new Vector3(hDir, 0, zDir)*moveSpeed*Time.fixedDeltaTime);
        rb.MovePosition(newPos);   
    }
}
