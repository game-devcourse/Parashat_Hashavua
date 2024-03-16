using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOnTrigger : MonoBehaviour
{
   [SerializeField] string triggerTag;
   [SerializeField] GameObject DialogueObject;
   [SerializeField] bool isAllDialogueOnTrigger;


    void Awake()
    {
        if(isAllDialogueOnTrigger)
        {
            DialogueObject.GetComponent<StartTalking>().enabled = false;
            DialogueObject.GetComponent<StartTalking>().Disable();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggerTag) {
            DialogueObject.GetComponent<StartTalking>().enabled = true;
            DialogueObject.GetComponent<StartTalking>().Enable();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == triggerTag) {
            DialogueObject.GetComponent<StartTalking>().enabled = false;
            DialogueObject.GetComponent<StartTalking>().Disable();
        }
    }
}