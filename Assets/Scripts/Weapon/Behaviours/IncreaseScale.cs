using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScale : MonoBehaviour
{
    private Transform parent;
    [SerializeField]private float xMaxScale;
    private float origXScale;

    private void Awake() {
        parent = transform.parent.transform;
        origXScale = parent.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J)){
            if(parent.localPosition.x > xMaxScale) return;
            parent.localPosition = new Vector3(parent.localPosition.x+Time.deltaTime*5f, parent.localPosition.y, parent.localPosition.z);
        }

        else if(parent.localPosition.x > origXScale && Mathf.Abs(parent.parent.GetComponent<PlayerRotation>().GetChargedRotSpeed())<3){
            parent.localPosition = new Vector3(parent.localPosition.x-Time.deltaTime*5f, parent.localPosition.y, parent.localPosition.z);
        }
    }
}
