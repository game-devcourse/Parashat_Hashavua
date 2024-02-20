using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//taken from https://www.youtube.com/watch?v=_nRzoTzeyxU with adaptation to our needs
[System.Serializable]
public class DialogueLine
{
    public string name;
    public string sentence; //to hold the sentence we want to display
    /**
    *this next parameters are for a scene that needs to be display multipule times each time with a different sentenct
    *so we want to keep the previous scene in which we entered from to the current one
    *and the other one is the next scene to wich we want to enter after the current one.
    *and in general each dialogue line can hold both of them only one or none if it hold the exitScene it means that after this 
    *line there should be transition to another scene if it dosen't hold the exitScene it means that we need to continue the conversation.
    **/
    public string enterScene; 
    public string exitScene;
}

//a dialogue object to hold all the lines
[System.Serializable]
public class Dialogue
{
    public DialogueLine[] dialogueLines;
}

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
