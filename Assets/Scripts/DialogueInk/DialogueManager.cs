using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance {get; private set;}
    private void Awake() {
        if(instance){
            Debug.LogError("More than one dialogue manager class");
            return;
        }
        instance = this;
    }

    [SerializeField]private TextMeshProUGUI textBox;
    private Story currentStory = null;
    private bool dialogueIsPlaying = false;
    //Don't repeat already read stories
    private TextAsset currentTextAsset;
    [SerializeField]private List<TextAsset> alreadyFinishedStories = new List<TextAsset>();

    private void Start() {
        gameObject.SetActive(false);
    }

    private void Update() {
        if(!dialogueIsPlaying) return;
    }

    public void SetDialogue(TextAsset textAsset){
        //Don't repeat already read stories
        if(alreadyFinishedStories.Contains(textAsset)){
            Debug.Log("ALREADY READ");
            return;
        }
        currentTextAsset = textAsset;
        //Don't change/reset the story when it is currently being read but just continue it
        if(currentStory != null){
            ContinueStory();
            return;
        }
        currentStory = new Story(textAsset.text);
        dialogueIsPlaying = true;
        gameObject.SetActive(true);
        
    }

    void ExitDialogue(){
        gameObject.SetActive(false);
        dialogueIsPlaying = false;
        textBox.text = "";

        //Add the current story as already read
        alreadyFinishedStories.Add(currentTextAsset);
        currentStory = null;
    }

    void ContinueStory(){
        if(currentStory.canContinue){
            textBox.text = currentStory.Continue();
        }else{
            ExitDialogue();
        }
    }


}
