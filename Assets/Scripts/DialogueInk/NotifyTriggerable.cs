using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyTriggerable : MonoBehaviour
{
    [SerializeField]private GameObject triggerBox;
    // Start is called before the first frame update
    void Start()
    {
        triggerBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            triggerBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player"){
            triggerBox.SetActive(false);
        }
    }
}
