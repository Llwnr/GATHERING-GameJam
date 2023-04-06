using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogue : MonoBehaviour
{
    [SerializeField]private TextAsset textAsset;
    [SerializeField]private GameObject triggerCue;

    // Update is called once per frame
    void Update()
    {
        //Only activate dialogue when player is in range
        if(triggerCue.activeSelf && Input.GetKeyDown(KeyCode.Space)){
            DialogueManager.instance.SetDialogue(textAsset);
        }
    }
}
