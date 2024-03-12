using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
