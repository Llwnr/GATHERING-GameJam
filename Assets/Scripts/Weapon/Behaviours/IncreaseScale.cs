using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScale : MonoBehaviour
{
    private Transform parent;
    [SerializeField]private float xMaxScale;
    private float origYScale;

    private void Awake() {
        parent = transform;
        origYScale = parent.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J)){
            if(parent.localPosition.y > xMaxScale) return;
            parent.localPosition = new Vector3(parent.localPosition.x, parent.localPosition.y+Time.deltaTime*5f, parent.localPosition.z);
        }

        else if(parent.localPosition.y > origYScale && Mathf.Abs(parent.parent.transform.parent.GetComponent<PlayerRotation>().GetChargedRotSpeed())<3){
            parent.localPosition = new Vector3(parent.localPosition.x, parent.localPosition.y-Time.deltaTime*5f, parent.localPosition.z);
        }
    }
}
