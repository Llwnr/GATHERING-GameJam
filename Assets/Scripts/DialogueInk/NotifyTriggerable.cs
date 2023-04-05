using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyTriggerable : MonoBehaviour
{
    [SerializeField]private GameObject triggerCue;
    // Start is called before the first frame update
    void Start()
    {
        triggerCue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            triggerCue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player"){
            triggerCue.SetActive(false);
        }
    }
}
