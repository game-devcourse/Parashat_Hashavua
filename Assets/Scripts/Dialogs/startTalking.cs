using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class starTalking : MonoBehaviour
{
    [SerializeField] InputAction nextSentence = new InputAction(type: InputActionType.Button);
    [SerializeField] DialogueTrigger dialogue;
    [SerializeField] DialogueManager dialogueManager;

    void OnEnable()
    {
        nextSentence.Enable();
    }

    void OnDisable()
    {
        nextSentence.Disable();
    }

    void Start()
    {
        dialogue.TriggerDialogue();
    }

    void Update()
    {
        if (nextSentence.WasPressedThisFrame()) 
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
