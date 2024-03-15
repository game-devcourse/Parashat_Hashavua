using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This script is meant to manage the starting and the duration of a conversation 
//it responsible to create the dialogue triger and manager ans call for the displaying of the sentences in each input action.
public class StartTalking : MonoBehaviour
{
    [SerializeField] InputAction nextSentence = new InputAction(type: InputActionType.Button);
    [SerializeField] DialogueTrigger dialogue;
    [SerializeField] DialogueManager dialogueManager;
    private bool canTalk = true;

    void OnEnable()
    {
        nextSentence.Enable();
    }

    void OnDisable()
    {
        nextSentence.Disable();
    }

    //enable and disable the option to talk
    public void Enable()
    {
        canTalk = true;
        dialogueManager.displayScrol();
    }

    public void Disable()
    {
        canTalk = false;
        dialogueManager.UnDisplayScrol();
    }

    //managing the option answers event
    public void OptionAnswersEventStart()
    {
        canTalk = false; // Disable ability to advance dialogue
    }

    // Method to handle Option Answers event end
    public void OptionAnswersEventEnd()
    {
        canTalk = true; // Enable ability to advance dialogue
    }

    void Start()
    {
        dialogue.TriggerDialogue();
    }

    void Update()
    {
        if (nextSentence.WasPressedThisFrame() && canTalk) 
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}